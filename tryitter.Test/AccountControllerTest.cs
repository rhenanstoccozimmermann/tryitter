namespace Tryiiter.test
{
    public class AccountControllerTest
    {
        [Fact]
        public void Test_AddAccount_Fail()
        {
            var accountFail = new Account()
            {
                Name = "IngridProPlayer",
            };
            Account? account = null;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IAccountService>();
            mockService.Setup(x=>x.AddAccount(accountFail)).Returns(account);

            //Act
            // criar uma instancia do controller
            var accountController = new AccountController(mockService.Object);
            var response  = accountController.AddAccount(accountFail) as BadRequestObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(BadRequestObjectResult));
            response?.Value.Should().Be("Dados inválidos");
        }

        
        [Fact]
        public void Test_AddAccount_Success()
        {
            var account = new Account()
            {
                Name =  "ingrid",
                Email = "string@hotmail.com",
                Password =  "stridsfsdfgdfgdfgdfng",
                Module = "fundamentos",
                Status =  1
            };

               var accountReturned = new Account()
            {
                AccountId = 1,
                Name =  "ingrid",
                Email = "string@hotmail.com",
                Password =  "stridsfsdfgdfgdfgdfng",
                Module = "fundamentos",
                Status =  1
            };
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IAccountService>();
            mockService.Setup(x=>x.AddAccount(account)).Returns(accountReturned);

            //Act
            // criar uma instancia do controller
            var accountController = new AccountController(mockService.Object);
            var response  = accountController.AddAccount(account) as OkObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(OkObjectResult));
            response?.Value.Should().BeEquivalentTo(accountReturned);
        }

        [Fact]
        public void Test_GetAccountById_Fail() {         
            Account? account = null;
            var mockId = 99999;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IAccountService>();
            mockService.Setup(x=>x.GetAccountById(mockId)).Returns(account);

            //Act
            // criar uma instancia do controller
            var accountController = new AccountController(mockService.Object);
            var response  = accountController.GetAccountById(mockId) as NotFoundObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(NotFoundObjectResult));
            response?.Value.Should().Be("Conta não encontrada");
        }

        [Fact]
        public void Test_GetAccountById_Success() {         
            Account account =  new Account()
            {
                AccountId = 1,
                Name =  "ingrid",
                Email = "string@hotmail.com",
                Password =  "stridsfsdfgdfgdfgdfng",
                Module = "fundamentos",
                Status =  1
            };
            var mockId = 1;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IAccountService>();
            mockService.Setup(x=>x.GetAccountById(mockId)).Returns(account);

            //Act
            // criar uma instancia do controller
            var accountController = new AccountController(mockService.Object);
            var response  = accountController.GetAccountById(mockId) as OkObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(OkObjectResult));
            response?.Value.Should().BeEquivalentTo(account);
        }

    }
}