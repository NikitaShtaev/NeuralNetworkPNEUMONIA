using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkClasses;
using System.Collections.Generic;

namespace NeuralNetworkClasses.Tests
{
    [TestClass()]
    public class ImageConverterTests
    {
        [TestMethod()]
        public void ConvertImageTest()
        {
            //Arrange
            var converter = new ImageConverter();
            var testCollection = converter.LoadImages(@"E:\Книги по программированию\DataSets\chest_xray\chest_xray\train\PNEUMONIA10", 10);
            List<double[]> testConvert = new List<double[]>();
            //Act
            for (int i = 0; i < testCollection.Length; i++)
            {
                testConvert.Add(converter.ConvertImage(testCollection[i]));
            }
            //Assert
            Assert.IsNotNull(testConvert);
        }
    }
}