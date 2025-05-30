// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace ControlWork3;

/// <summary>
/// Represents a sparse vector implementation that efficiently stores and manipulates
/// high-dimensional vectors where most elements are zero.
/// </summary>
public class SparseVector
{
    private readonly Dictionary<int, double> elements;

    /// <summary>
    /// Gets the dimension (size) of the vector
    /// </summary>
    /// <value>The number of elements in the vector</value>
    public int Dimension { get; }

    /// <summary>
    /// Initializes a new instance of the SparseVector class with specified dimension
    /// </summary>
    /// <param name="dimension">The size of the vector (must be greater than zero)</param>
    /// <exception cref="ArgumentException">Thrown when dimension is less than or equal to zero</exception>
    public SparseVector(int dimension)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException("Dimension must be greater than zero", nameof(dimension));
        }

        Dimension = dimension;
        elements = new Dictionary<int, double>();
    }

    /// <summary>
    /// Gets or sets the element at the specified index
    /// </summary>
    /// <param name="key">The zero-based index of the element to get or set</param>
    /// <value>The value at the specified index (returns 0.0 for unset indices)</value>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is out of range</exception>
    /// <remarks>
    /// Setting an element to zero (within epsilon tolerance) removes it from sparse storage
    /// </remarks>
    public double this[int key]
    {
        get
        {
            this.CheckIndex(key);
            return this.elements.TryGetValue(key, out var value) ? value : 0.0;
        }
        set
        {
            this.CheckIndex(key);
            var epsilon = 0.000001;
            if (Math.Abs(0.0 - value) > epsilon)
            {
                this.elements[key] = value;
            }
            else
            {
                this.elements.Remove(key);
            }
        }
    }

    /// <summary>
    /// Adds two sparse vectors element-wise
    /// </summary>
    /// <param name="firstVector">First vector to add</param>
    /// <param name="secondVector">Second vector to add</param>
    /// <returns>New sparse vector containing the element-wise sum</returns>
    /// <exception cref="ArgumentNullException">Thrown when either vector is null</exception>
    /// <exception cref="ArgumentException">Thrown when vectors have different dimensions</exception>
    public static SparseVector operator +(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector == null || secondVector == null)
            throw new ArgumentNullException();
        if (firstVector.Dimension != secondVector.Dimension)
            throw new ArgumentException("Vectors must have the same dimension");
        
        var result = new SparseVector(firstVector.Dimension);

        for (var i = 0; i < firstVector.Dimension; i++)
        {
            result[i] = firstVector[i] + secondVector[i];
        }
        
        return result;
    }
    
    /// <summary>
    /// Subtracts two sparse vectors element-wise
    /// </summary>
    /// <param name="firstVector">Vector to subtract from</param>
    /// <param name="secondVector">Vector to subtract</param>
    /// <returns>New sparse vector containing the element-wise difference</returns>
    /// <exception cref="ArgumentNullException">Thrown when either vector is null</exception>
    /// <exception cref="ArgumentException">Thrown when vectors have different dimensions</exception>
    public static SparseVector operator -(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector == null || secondVector == null)
            throw new ArgumentNullException();
        if (firstVector.Dimension != secondVector.Dimension)
            throw new ArgumentException("Vectors must have the same dimension");
        
        var result = new SparseVector(firstVector.Dimension);

        for (var i = 0; i < firstVector.Dimension; i++)
        {
            result[i] = firstVector[i] - secondVector[i];
        }
        
        return result;
    }
    
    /// <summary>
    /// Computes the dot product of two sparse vectors
    /// </summary>
    /// <param name="firstVector">First vector in the product</param>
    /// <param name="secondVector">Second vector in the product</param>
    /// <returns>The dot product (sum of element-wise products)</returns>
    /// <exception cref="ArgumentNullException">Thrown when either vector is null</exception>
    /// <exception cref="ArgumentException">Thrown when vectors have different dimensions</exception>
    public static double operator *(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector == null || secondVector == null)
            throw new ArgumentNullException();
        if (firstVector.Dimension != secondVector.Dimension)
            throw new ArgumentException("Vectors must have the same dimension");
        
        var result = 0.0;

        for (var i = 0; i < firstVector.Dimension; i++)
        {
            result += firstVector[i] * secondVector[i];
        }
        
        return result;
    }

    /// <summary>
    /// Validates that an index is within the valid range for this vector
    /// </summary>
    /// <param name="index">Index to validate</param>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is out of range</exception>
    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Dimension)
        {
            throw new IndexOutOfRangeException($"Index must be between 0 and {Dimension - 1}");
        }
    }
    
    /// <summary>
    /// Determines whether the vector contains only zero elements
    /// </summary>
    /// <returns>true if all elements are zero; otherwise, false</returns>
    public bool IsZero()
    {
        return this.elements.Count == 0;
    }
}