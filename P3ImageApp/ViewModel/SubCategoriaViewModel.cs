using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P3ImageApp.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace P3ImageApp.ViewModel
{
    public class SubCategoriaViewModel
    {
        public Tab_Subcategoria subCategoria { get; set; }

        public SubCategoriaViewModel(String slugcategoria, String slugsubcategoria)
        {
            using (BD_P3IMAGEContext db = new BD_P3IMAGEContext())
            {
                subCategoria = db.Tab_Subcategoria.Include(s => s.Tab_Categoria).Include(s => s.Tab_Campo)
                                                            .Where(s => s.Tab_Categoria.slug == slugcategoria
                                                            && s.slug == slugsubcategoria
                                                            ).FirstOrDefault();
            }
        }

        /// <summary>
        /// retornaTipo
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="tipo"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static IHtmlString retornaTipo(string descricao, string tipo, string lista)
        {
            string retorno = String.Empty;

            switch(tipo){
                case "text": retorno = "<input type='text' name='" + descricao + "'>";
                    break;
                case "textarea": retorno = "<textarea rows='4' cols='50' name='" + descricao + "'></textarea>";
                    break;
                case "select": retorno = MontaSelect(descricao, lista);
                    break;
                case "checkbox": retorno = MontaCheckBox(descricao, lista);
                    break;
                default : retorno = String.Empty;
                    break;
            }

            return new HtmlString(retorno);
        }

        /// <summary>
        /// MontaSelect
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        private static string MontaSelect(string descricao, string lista)
        {
            //["Opção1", "Opção2", "Opção3"]
            string select = String.Empty;
            select = "<select name='"+descricao+"'>";

            if (!String.IsNullOrEmpty(lista))
            {
                lista = lista.Replace("[", "").Replace("]", "").Replace("\"","").Trim();

                string[] words = lista.Split(',');
                foreach (string word in words)
                {
                    select = select + "<option value='" + word.Trim() + "'>" + word.Trim() + "</option>";
                }
            }

            select = select + "</select>";
            return select;
        }

        /// <summary>
        /// MontaCheckBox
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        private static string MontaCheckBox(string descricao, string lista)
        {
            //["Opção1", "Opção2", "Opção3"]
            string checkBox = String.Empty;

            if (!String.IsNullOrEmpty(lista))
            {
                //"<input type='checkbox' name='" + descricao + "' value='" + descricao + "'>" + descricao;           
                lista = lista.Replace("[", "").Replace("]", "").Replace("\"", "").Trim();

                string[] words = lista.Split(',');
                foreach (string word in words)
                {
                    checkBox = checkBox + "<input type='checkbox' name='" + word + "' value='" + word + "'>" + word;
                }
            }

            return checkBox;
        }
    }
}