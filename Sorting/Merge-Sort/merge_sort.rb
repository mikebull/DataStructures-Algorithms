class MergeSort
  def initialize(arr)
    @arr = arr.shuffle
  end

  def sort
    @arr = mergesort(@arr)
  end

  def mergesort(arr)
    # If array is empty, no need to split/merge
    return arr if arr.size <= 1

    left, right = arr.each_slice( (arr.size / 2.0).floor ).to_a

    # Recursively break down and assign to new variables
    left_sorted = mergesort(left)
    right_sorted = mergesort(right)

    merge(left_sorted, right_sorted)
  end

  def merge(left, right)
    # If one is empty, the other has won
    return left if right.empty?
    return right if left.empty?

    # Pop smallest value
    smallest_value = if left.first <= right.first
        left.shift
      else
        right.shift
      end

    arr = merge(left, right)

    # Smallest value is smallest element, so add 
    # to start of arr, and build from call stack
    [smallest_value].concat(arr)
  end

  def list
    @arr.join(", ")
  end
end
