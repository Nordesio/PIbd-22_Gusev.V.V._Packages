using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareInstallationShopBusinessLogic.OfficePackage.HelperEnums;
using SoftwareInstallationShopBusinessLogic.OfficePackage.HelperModels;
namespace SoftwareInstallationShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new
WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            string tab = ":\t";
            foreach (var package in info.Packages)
            {
                CreateParagraph(new WordParagraph
                {

                    Texts = new List<(string, WordTextProperties)> { (package.PackageName, new WordTextProperties { Size = "24", Bold = true}),
                                                                      (tab, new WordTextProperties{ Size ="24", }),
                                                                      (package.Price.ToString(), new WordTextProperties{ Size ="24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateWord(WordInfo info);
        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SaveWord(WordInfo info);
    }
}
