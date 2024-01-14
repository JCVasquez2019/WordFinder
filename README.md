# WordFinder

Web API to create a matrix of chars and find words on it, there are 3 endpoints where yo can create a matrix from a array of strings and Find words.

This Web API was built with clean architecture, using MediatR which helps in decoupling the components of an application, and using Repository and Unit Of Work pattern to data access.
{Image1}

## Matrix
### Create

There is a POST endpoint to create matrix and store in a memory database, the payload to use the endpoint is:
```json
{
  "name": "Animals",
  "items": [
    "UHZOUTDBZGYE", 
	"DNXTBEARBMGR",
	"ODAHKLCATXBV",
	"GRVOEJLLOOLI", 
	"OHNLIONTIUIS",
	"AUYXRABBITOK", 
	"NJPVUNQCFJNQ",
	"CSALPNEOYJNK"
  ]
}
```
And before adding this it is validated using  FluentValidation, the validations are:
- The matrix size does not exceed 64x64
- All strings contain the same number of characters

For example:
```json
{
  "Items": [
    "The Items must have the same size."
  ]
}
```
### Get by ID
You can get a matrix by ID, using a GET endpoint:
 {image2}


### Default Data
When the app is initialization three matrix are created as a default data.
```csharp
public class ApplicationContextSeed
{
    public static async Task SeedAsync(ApplicationContext matrixContext)
    {
        await matrixContext.Matrix.AddRangeAsync(new Domain.Entities.Matrix[] {
            new Matrix
            {
                Id = 1,
                Name = "Animals",
                Items = "UHZOUTDBZGYE,DNXTBEARBMGR,ODAHKLCATXBV,GRVOEJLLOOLI,OHNLIONTIUIS,AUYXRABBITOK,NJPVUNQCFJNQ,CSALPNEOYJNK"
            },
            new Matrix
            {
                Id = 2,
                Name = "Foods",
                Items = "GRAPEALLLGMT,APPLEPPEBBAC,FTHGNPAMAANH,ESMDOLVONNGQ,AAPPLERNAAOH,CHERRIESNNLV,KIWIJDONAAGI,KYCLEMONTXCO"
            },
            new Matrix
            {
                Id = 3,
                Name = "Colors",
                Items = "URSREDLAANGF,BCZMGREENSGD,CBLACKRSWVRB,CDAJBLUEKTEL,GTXJYELLOWEA,AOBLUEDLVKNC,PWKWCWHITEFK,SYLBREDHLAUR"
            }

        });
        await matrixContext.SaveChangesAsync();
    }
}
```
These are the data and the words that you can find in the matrix:
- Animals
```bash
UHZOUTDBZGYE, 
DNXTBEARBMGR,
ODAHKLCATXBV,
GRVOEJLLOOLI, 
OHNLIONTIUIS,
AUYXRABBITOK, 
NJPVUNQCFJNQ,
CSALPNEOYJNK
```
you can find:
```bash
BEAR
DOG
CAT
LION
RABBIT
```
- Food
```bash
GRAPEALLLGMT,
APPLEPPEBBAC,
FTHGNPAMAANH,
ESMDOLVONNGQ,
AAPPLERNAAOH,
CHERRIESNNLV,
KIWIJDONAAGI,
KYCLEMONTXCO
```
you can find:
```bash
GRAPE
APPLE
APPLE
APPLE
BANANA
BANANA
LEMON
LEMON
CHERRIES
MANGO
KIWI
```
- Colors
```bash
URSREDLAANGF,
BCZMGREENSGD,
CBLACKRSWVRB,
CDAJBLUEKTEL,
GTXJYELLOWEA,
AOBLUEDLVKNC,
PWKWCWHITEFK,
SYLBREDHLAUR
```
you can find:
```bash
RED
RED
GREEN
GREEN
BLACK
BLACK
BLUE
BLUE
YELLOW
WHITE
```
## Word Finder

The endpoint WordFinder find an array of words in the matrix selected, the payload is:
```json
{
  "matrixId": 3,
  "top":3,
  "namesToFind": [
    "RED",
    "GREEN",
    "BLACK",
    "BLUE",
    "YELLOW",
    "WHITE",
    "PURPLE"
  ]
}

```
The top attribute is optional, by default it returns the ten most repeated words.
The result for the previous endpoint is:

```bash
[
  "RED",
  "GREEN",
  "BLACK"
]
```
## Algorithm

The algorithm initially iterates the words that will be searched in the matrix and obtains the number of times it appears in the matrix, after this it stores the results in a dictionary indicating the word found and the times it was found, after that it is ordered descendingly and take the top indicated in the input parameter.

```csharp
 public IEnumerable<string> Find(IEnumerable<string> words, int top)
 {
     Dictionary<string, int> results = new Dictionary<string, int>();
     char[,] letterMatrix = MatrixCreator.CreateMatrixFromStringArray(_matrix);

     foreach (string word in words)
     {
         int count = Find(word.ToUpper(), letterMatrix);
         if (count > 0)
             results.Add(word.ToUpper(), count);
     }
     return GetMoreRepeatedWords(results, top);
 }
```
The Find algorithm searches for a word within the matrix, it goes through the matrix looking for the initial letter of the word once it finds it, it first searches vertically, before entering the search method the size of the word is verified and if It is possible to find it. If it is not possible, do not enter the search method, then do the same to search horizontally.


```csharp
private int Find(string word, char[,] letterMatrix)
 {
     int rows = letterMatrix.GetLength(0);
     int columns = letterMatrix.GetLength(1);
     int counter = 0;

     for (int i = 0; i < rows; i++)
     {
         for (int j = 0; j < columns; j++)
         {
             if (letterMatrix[i, j] == word[0])
             {
                 if ((rows - i > word.Length) && FindInDirection(letterMatrix, word, i, j, 1, 0))// vertical search
                     counter++;

                 if ((columns - i > word.Length) && FindInDirection(letterMatrix, word, i, j, 0, 1))// horizontal search
                     counter++;
             }
         }
     }
     return counter;
 }
```
