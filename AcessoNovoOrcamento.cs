using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using QuiverPro.ClassesNavega;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

namespace QuiverPro
{
    /// <summary>
    /// Descrição resumida para UnitTest2
    /// </summary>
    [TestClass]
    public class AcessoNovoOrcamento
    {
        public AcessoNovoOrcamento()
        {
            //
            // TODO: Adicionar lógica de construtor aqui
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Esse teste faz acesso a tela de novo orçamento.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public IJavaScriptExecutor Driver { get; private set; }

        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {

            #region classes utilizadas para navegação.
            DadosLogin login = new DadosLogin();
            NavegaMenu navega = new NavegaMenu();
            #endregion

            IWebDriver driver = login.LogarNoSistema();
            System.Threading.Thread.Sleep(8000);
            // driver = navega.NavegaOperacional(driver);

            driver = navega.NavegaVendas(driver);
            System.Threading.Thread.Sleep(4000);

            //comando para acesso ao iframe 
            driver.SwitchTo().Frame("ZonaInterna");
            driver.FindElement(By.ClassName("submenunovotitulo"));

            //escolhendo o menu por javascript executando função diretamente.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("SelecionaModuloJQuery('','NOVOORCAMENTO','AcompanhamentoVendas|Professional','NOVOORCAMENTO','Novo orçamento');");

            System.Threading.Thread.Sleep(5000);
            js.ExecuteScript("AcionaOpcaoFast('289', 'Fast/FrmAjax.aspx?pagina=MultCalculo&Padrao=289&Calculo=0&Tipoproduto=A', 'MultiNovo', '', 'PADRAO CO CORRETOR')");
            System.Threading.Thread.Sleep(3000);
            driver.SwitchTo().Frame("ZonaInterna");
            driver.FindElement(By.Id("Padrao2000_Cobertura21")).Click();
            IWebElement elemento = driver.FindElement(By.Id("Padrao2000_Cobertura7187"));
            SelectElement combo = new SelectElement(elemento);
            combo.SelectByValue("1");
            driver.FindElement(By.Id("Padrao2000_Iniciovigencia")).SendKeys(Keys.Control+"A");
            driver.FindElement(By.Id("Padrao2000_Iniciovigencia")).SendKeys(Keys.Backspace);
            DateTime iniVigencia = DateTime.Today.AddDays(1);
            driver.FindElement(By.Id("Padrao2000_Iniciovigencia")).SendKeys(iniVigencia.ToString());
            driver.FindElement(By.Id("Padrao2000_Iniciovigencia")).SendKeys(Keys.Tab);
            System.Threading.Thread.Sleep(1000);
            IWebElement comboTipoDeCobertura = driver.FindElement(By.Id("Padrao2000_Tipo_cobertura"));
            SelectElement comboTipoDeCoberturaResp = new SelectElement(comboTipoDeCobertura);
            comboTipoDeCoberturaResp.SelectByValue("1");
            driver.FindElement(By.Id("Padrao2000_Tipo_pessoaJ")).Click();
            driver.FindElement(By.Id("Padrao2000_Observacoes")).SendKeys("Teste automação campo observações cotação");
            driver.FindElement(By.XPath("//*[@id=\"DIVPadrao2000_Grupo_hierarquico\"]/div/span/span[1]/span")).Click();
            driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("FELIPE TESTE");
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
            driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("Padrao2000_Cgc_cpf")).SendKeys("72408271000191");
            driver.FindElement(By.Id("Padrao2000_Cgc_cpf")).SendKeys(Keys.Tab);
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("Padrao2000_Cobertura73175")).Click();
            driver.FindElement(By.XPath("//*[@id=\"DIVPadrao2000_Modelo\"]/div/span/span[1]/span")).Click();
            driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("PYC2530");
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
            driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(45000);
            driver.FindElement(By.Id("Padrao2000_Cobertura60892")).Click();
            driver.FindElement(By.Id("Padrao2000_Cobertura70652")).Click();
            driver.FindElement(By.Id("Padrao2000_Cobertura1902")).Click();
            driver.FindElement(By.Id("Padrao2000_Cobertura1851_Bt")).Click();
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.Id("DIVEndereco")).Click();
            driver.FindElement(By.Id("select2-Estado-container")).Click();
            driver.FindElement(By.Id("select2-Estado-container")).SendKeys("PR");

            // driver.FindElement(By.Id("DIVPadrao2000_Cobertura1851")).SendKeys(Keys.Tab);









        }
    }
}
