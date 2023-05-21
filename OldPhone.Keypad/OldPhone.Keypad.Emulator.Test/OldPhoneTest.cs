using NUnit.Framework;

namespace OldPhone.Keypad.Emulator.Test
{
    [TestFixture]
    public class OldPhoneTest
    {
        #region Invalid_Input

        [Test]
        [TestCase("2222")]
        public void Invalid_Input_final_rout_missing(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.IsTrue(output.StartsWith("Error"));
        }

        [Test]
        [TestCase("*22#")]
        public void Invalid_Input_starts_with_asterisk(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.IsTrue(output.StartsWith("Error"));
        }

        [Test]
        [TestCase("22 22*****#")]
        public void Invalid_Input_digits_followed_too_many_asterisks(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.IsTrue(output.StartsWith("Error"));
        }

        [Test]
        [TestCase("")]
        public void Invalid_Input_empty(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.IsTrue(output.StartsWith("Error"));
        }
        
        #endregion // Invalid_Input

        #region Key_Backspace

        [Test]
        [TestCase("2222*#")]
        public void Backspace_Key_222(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("C"));
        }

        [Test]
        [TestCase("22**2#")]
        public void Backspace_Key_22(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("A"));
        }

        [Test]
        [TestCase("2222***#")]
        public void Backspace_Key_2(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("A"));
        }

        #endregion // Key_Backspace

        #region Dictionary

        #region Key_0

        [Test]
        [TestCase("0#")]
        public void Input_Key_0(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("0"));
        }

        [Test]
        [TestCase("00#")]
        public void Input_Key_00(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo(" "));
        }

        #endregion // Key_0

        #region Key_1

        [Test]
        [TestCase("1#")]
        public void Input_Key_1(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("&"));
        }

        [Test]
        [TestCase("11#")]
        public void Input_Key_11(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("'"));
        }

        [Test]
        [TestCase("111#")]
        public void Input_Key_111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("("));
        }

        [Test]
        [TestCase("1111#")]
        public void Input_Key_1111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo(")"));
        }

        [Test]
        [TestCase("11111#")]
        public void Input_Key_11111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("*"));
        }

        [Test]
        [TestCase("111111#")]
        public void Input_Key_111111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo(","));
        }

        [Test]
        [TestCase("1111111#")]
        public void Input_Key_1111111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("-"));
        }

        [Test]
        [TestCase("11111111#")]
        public void Input_Key_11111111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("."));
        }

        [Test]
        [TestCase("111111111#")]
        public void Input_Key_111111111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("/"));
        }

        [Test]
        [TestCase("1111111111#")]
        public void Input_Key_1111111111(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("1"));
        }

        #endregion // Key_1

        #region Key_2

        [Test]
        [TestCase("2#")]
        public void Input_Key_2(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("A"));
        }

        [TestCase("22#")]
        public void Input_Key_22(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("B"));
        }

        [TestCase("222#")]
        public void Input_Key_222(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("C"));
        }

        [TestCase("2222#")]
        public void Input_Key_2222(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("2"));
        }

        #endregion // Key_2

        #region Key_3

        [Test]
        [TestCase("3#")]
        public void Input_Key_3(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("D"));
        }

        [TestCase("33#")]
        public void Input_Key_33(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("E"));
        }

        [TestCase("333#")]
        public void Input_Key_333(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("F"));
        }

        [TestCase("3333#")]
        public void Input_Key_3333(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("3"));
        }

        #endregion // Key_3

        #region Key_4

        [Test]
        [TestCase("4#")]
        public void Input_Key_4(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("G"));
        }

        [TestCase("44#")]
        public void Input_Key_44(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("H"));
        }

        [TestCase("444#")]
        public void Input_Key_444(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("I"));
        }

        [TestCase("4444#")]
        public void Input_Key_4444(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("4"));
        }

        #endregion // Key_4

        #region Key_5

        [Test]
        [TestCase("5#")]
        public void Input_Key_5(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("J"));
        }

        [TestCase("55#")]
        public void Input_Key_55(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("K"));
        }

        [TestCase("555#")]
        public void Input_Key_555(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("L"));
        }

        [TestCase("5555#")]
        public void Input_Key_5555(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("5"));
        }

        #endregion // Key_5

        #region Key_6

        [Test]
        [TestCase("6#")]
        public void Input_Key_6(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("M"));
        }

        [TestCase("66#")]
        public void Input_Key_66(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("N"));
        }

        [TestCase("666#")]
        public void Input_Key_666(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("O"));
        }

        [TestCase("6666#")]
        public void Input_Key_6666(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("6"));
        }

        #endregion // Key_6

        #region Key_7

        [Test]
        [TestCase("7#")]
        public void Input_Key_7(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("P"));
        }

        [TestCase("77#")]
        public void Input_Key_77(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("Q"));
        }

        [TestCase("777#")]
        public void Input_Key_777(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("R"));
        }

        [TestCase("7777#")]
        public void Input_Key_7777(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("S"));
        }

        [TestCase("77777#")]
        public void Input_Key_77777(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("7"));
        }

        #endregion // Key_7

        #region Key_8

        [Test]
        [TestCase("8#")]
        public void Input_Key_8(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("T"));
        }

        [TestCase("88#")]
        public void Input_Key_88(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("U"));
        }

        [TestCase("888#")]
        public void Input_Key_888(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("V"));
        }

        [TestCase("8888#")]
        public void Input_Key_8888(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("8"));
        }

        #endregion // Key_8

        #region Key_9

        [Test]
        [TestCase("9#")]
        public void Input_Key_9(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("W"));
        }

        [TestCase("99#")]
        public void Input_Key_99(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("X"));
        }

        [TestCase("999#")]
        public void Input_Key_999(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("Y"));
        }

        [TestCase("9999#")]
        public void Input_Key_9999(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("Z"));
        }

        [TestCase("99999#")]
        public void Input_Key_99999(string input)
        {
            // Arange
            string keyInput = input;

            // Act
            string output = OldPhone.OldPhonePad(keyInput);

            // Assert
            Assert.That(output, Is.EqualTo("9"));
        }

        #endregion // Key_9

        #endregion // Dictionary
    }
}