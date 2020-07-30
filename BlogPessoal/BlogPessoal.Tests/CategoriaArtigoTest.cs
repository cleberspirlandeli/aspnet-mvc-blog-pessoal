using System;
using System.Linq;
using BlogPessoal.Web.Data.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoal.Tests
{
    [TestClass]
    public class CategoriaArtigoTest
    {
        [TestMethod]
        public void ConsultarArtigoComSucesso()
        {
            var _context = new Context();
            var categoriaArtigo =_context.CategoriaArtigo.FirstOrDefault();

            Assert.IsNotNull(categoriaArtigo);
        }
    }
}
