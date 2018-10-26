namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class BankAccountTests
    {
        //UnitOfWork_StateUnderTest_ExpectedBehavior

        [Test]
        public void BankAccountConstructor_InitializeAccountWithPositiveBalance_BalanceToBeEqualToInitialValue()
        {
            //Act
            var account = new BankAccount(2000m);

            //Assert
            Assert.That(account.Balance, Is.EqualTo(2000m));
        }

        [Test]
        public void BankAccountConstructor_InitializeAccountWithNegativeBalance_ThrowsException()
        {
            //Assert
            Assert.That(() => new BankAccount(-2000m), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void DepositMethod_AddPositiveAmount_AmountWillBeIncreased()
        {
            //Arrange
            var account = new BankAccount();

            //Act
            account.Deposit(50);

            //Assert
            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void DepositMethod_AddNegativeAmount_ThrowsException()
        {
            //Arrange
            var account = new BankAccount(150);

            //Assert
            Assert.That(() => account.Deposit(-50), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void DepositMethod_AddZeroAmount_ThrowsException()
        {
            //Arrange
            var account = new BankAccount(150);

            //Assert
            Assert.That(() => account.Deposit(0), Throws.Exception
                .TypeOf<ArgumentException>());
        }
    }
}