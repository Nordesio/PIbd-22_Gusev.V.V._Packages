using SoftwareInstallationShopBusinessLogic.OfficePackage.HelperEnums;
using System.Collections.Generic;

namespace SoftwareInstallationShopBusinessLogic.OfficePackage.HelperModels
{
    public class PdfRowParameters
    {
        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}