// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace ControlWork3.Tests;

using ControlWork3;

public class Tests
{
    [Test]
        public void Constructor_ValidDimension_CreatesInstance()
        {
            var vector = new SparseVector(5);
            Assert.That(5, Is.EqualTo(vector.Dimension));
            Assert.That(vector.IsZero(), Is.True);
        }

        [Test]
        public void Constructor_ZeroDimension_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SparseVector(0));
        }

        [Test]
        public void Constructor_NegativeDimension_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SparseVector(-1));
        }

        [Test]
        public void Indexer_GetSet_WorksCorrectly()
        {
            var vector = new SparseVector(3);
            vector[1] = 5.5;
            Assert.That(vector[1], Is.EqualTo(5.5));
            Assert.That(vector[0], Is.EqualTo(0.0));
            Assert.That(vector[2], Is.EqualTo(0.0));
        }

        [Test]
        public void Indexer_SetZero_RemovesElement()
        {
            var vector = new SparseVector(3);
            vector[1] = 5.5;
            vector[1] = 0.0;
            Assert.That(vector[1], Is.EqualTo(0.0));
            Assert.That(vector.IsZero(), Is.True);
        }

        [Test]
        public void Indexer_GetOutOfRange_ThrowsIndexOutOfRangeException()
        {
            var vector = new SparseVector(3);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = vector[3]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = vector[-1]; });
        }

        [Test]
        public void Indexer_SetOutOfRange_ThrowsIndexOutOfRangeException()
        {
            var vector = new SparseVector(3);
            Assert.Throws<IndexOutOfRangeException>(() => vector[3] = 1.0);
            Assert.Throws<IndexOutOfRangeException>(() => vector[-1] = 1.0);
        }

        [Test]
        public void OperatorAdd_ValidVectors_ReturnsCorrectResult()
        {
            var v1 = new SparseVector(3);
            var v2 = new SparseVector(3);
            
            v1[0] = 1.0;
            v1[2] = 2.0;
            v2[1] = 3.0;
            v2[2] = 4.0;
            
            var result = v1 + v2;
            
            Assert.That(result[0], Is.EqualTo(1.0));
            Assert.That(result[1], Is.EqualTo(3.0));
            Assert.That(result[2], Is.EqualTo(6.0));
        }

        [Test]
        public void OperatorAdd_DifferentDimensions_ThrowsArgumentException()
        {
            var v1 = new SparseVector(2);
            var v2 = new SparseVector(3);
            Assert.Throws<ArgumentException>(() => { var result = v1 + v2; });
        }

        [Test]
        public void OperatorAdd_NullVector_ThrowsArgumentNullException()
        {
            var v1 = new SparseVector(3);
            Assert.Throws<ArgumentNullException>(() => { var result = v1 + null; });
            Assert.Throws<ArgumentNullException>(() => { var result = null + v1; });
        }

        [Test]
        public void OperatorSubtract_ValidVectors_ReturnsCorrectResult()
        {
            var v1 = new SparseVector(3);
            var v2 = new SparseVector(3);
            
            v1[0] = 1.0;
            v1[2] = 5.0;
            v2[1] = 3.0;
            v2[2] = 4.0;
            
            var result = v1 - v2;
            
            Assert.That(result[0], Is.EqualTo(1.0));
            Assert.That(result[1], Is.EqualTo(-3.0));
            Assert.That(result[2], Is.EqualTo(1.0));
        }

        [Test]
        public void OperatorSubtract_DifferentDimensions_ThrowsArgumentException()
        {
            var v1 = new SparseVector(2);
            var v2 = new SparseVector(3);
            Assert.Throws<ArgumentException>(() => { var result = v1 - v2; });
        }

        [Test]
        public void OperatorSubtract_NullVector_ThrowsArgumentNullException()
        {
            var v1 = new SparseVector(3);
            Assert.Throws<ArgumentNullException>(() => { var result = v1 - null; });
            Assert.Throws<ArgumentNullException>(() => { var result = null - v1; });
        }

        [Test]
        public void OperatorMultiply_ValidVectors_ReturnsCorrectResult()
        {
            var v1 = new SparseVector(3);
            var v2 = new SparseVector(3);
            
            v1[0] = 1.0;
            v1[1] = 2.0;
            v1[2] = 3.0;
            
            v2[0] = 4.0;
            v2[1] = 5.0;
            v2[2] = 6.0;
            
            var result = v1 * v2;
            
            Assert.That(result, Is.EqualTo(32.0));
        }

        [Test]
        public void OperatorMultiply_DifferentDimensions_ThrowsArgumentException()
        {
            var v1 = new SparseVector(2);
            var v2 = new SparseVector(3);
            Assert.Throws<ArgumentException>(() => { var result = v1 * v2; });
        }

        [Test]
        public void OperatorMultiply_NullVector_ThrowsArgumentNullException()
        {
            var v1 = new SparseVector(3);
            Assert.Throws<ArgumentNullException>(() => { var result = v1 * null; });
            Assert.Throws<ArgumentNullException>(() => { var result = null * v1; });
        }

        [Test]
        public void IsZero_EmptyVector_ReturnsTrue()
        {
            var vector = new SparseVector(3);
            Assert.That(vector.IsZero(), Is.True);
        }

        [Test]
        public void IsZero_NonEmptyVector_ReturnsFalse()
        {
            var vector = new SparseVector(3);
            vector[1] = 1.0;
            Assert.That(vector.IsZero(), Is.False);
        }
}