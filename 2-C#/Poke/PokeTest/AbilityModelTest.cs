using PokeModel;
using Xunit;

namespace PokeTest
{

    public class AbilityModelTest
    {
        /// <summary>
        /// Checks the validation for PP property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void PPShouldSetValidData()
        {
            //Arrange
            Ability abi = new Ability();
            int validPP = 10;

            //Act
            abi.PP = validPP;

            //Assert
            Assert.NotNull(abi.PP); //checks that the property is not null meaning we did set data in this property
            Assert.Equal(validPP, abi.PP); //checks if the property does indeed hold the same value as what we set it as
        }

        /// <summary>
        /// Checks validation for PP property with incorrect data
        /// Should throw an exception
        /// </summary>
        [Fact]
        public void PPShouldFailSetInvalidData()
        {
            //Arrange
            Ability abi = new Ability();
            int invalidPP = -10;

            //Act & Assert
            Assert.Throws<System.Exception>(
                () => abi.PP = invalidPP
            );
        }
    }
}