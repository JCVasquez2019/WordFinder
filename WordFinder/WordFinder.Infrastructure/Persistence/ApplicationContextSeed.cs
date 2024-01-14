using Microsoft.Extensions.Logging;
using WordFinder.Domain.Entities;

namespace WordFinder.Infrastructure.Persistence
{
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
}
