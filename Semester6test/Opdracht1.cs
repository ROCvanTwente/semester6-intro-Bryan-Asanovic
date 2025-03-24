using Semester6.Controllers;
using static Semester6.Controllers.Opdracht1Controller;
using Xunit;
namespace Semester6test
{
    public class Opdracht1
    {
        [Fact]
        public void Encrypt_ShiftsCharactersCorrectly()
        {
            // Arrange
            string input = "Hello123";
            int key = 5;
            string expected = "Mjqqt678"; // Elke letter/cijfer is 5 posities opgeschoven

            // Act
            string result = EncryptionFunctions.Encrypt(input, key);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Encrypt_HandlesEmptyString()
        {
            Assert.Equal("", EncryptionFunctions.Encrypt("", 5));
        }

        [Fact]
        public void Encrypt_IgnoresNonAlphanumericCharacters()
        {
            Assert.Equal("!@#", EncryptionFunctions.Encrypt("!@#", 5));
        }

        [Fact]
        public void Encrypt_WrapsAroundAlphabet()
        {
            Assert.Equal("a", EncryptionFunctions.Encrypt("Z", 1));
        }

        [Fact]
        public void Decrypt_ShouldReturnOriginalText()
        {
            // Arrange
            string originalText = "Hello123";
            int key = 5;
            string encryptedText = DecryptionFunctions.Decrypt(originalText, -key);

            // Act
            string decryptedText = DecryptionFunctions.Decrypt(encryptedText, key);

            // Assert
            Assert.Equal(originalText, decryptedText);
        }

        [Fact]
        public void Decrypt_WithSpecialCharacters_ShouldIgnoreThem()
        {
            // Arrange
            string originalText = "Hello! 123?";
            int key = 3;
            string encryptedText = DecryptionFunctions.Decrypt(originalText, -key);

            // Act
            string decryptedText = DecryptionFunctions.Decrypt(encryptedText, key);

            // Assert
            Assert.Equal(originalText, decryptedText);
        }

        [Fact]
        public void Decrypt_WithZeroKey_ShouldReturnSameText()
        {
            // Arrange
            string originalText = "Test123";
            int key = 0;

            // Act
            string decryptedText = DecryptionFunctions.Decrypt(originalText, key);

            // Assert
            Assert.Equal(originalText, decryptedText);
        }

        [Fact]
        public void Decrypt_WithLargeKey_ShouldStillWork()
        {
            // Arrange
            string originalText = "SecureMessage42";
            int key = 1000; // Grote sleutel
            string encryptedText = DecryptionFunctions.Decrypt(originalText, -key);

            // Act
            string decryptedText = DecryptionFunctions.Decrypt(encryptedText, key);

            // Assert
            Assert.Equal(originalText, decryptedText);
        }
    }
}