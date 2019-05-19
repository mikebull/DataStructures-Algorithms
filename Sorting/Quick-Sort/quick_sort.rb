class QuickSort
  def initialize(arr)
    @arr = arr.shuffle
  end

  def sort
    quicksort(@arr, 0, @arr.length - 1)
  end

  def quicksort(arr, first, last)
    if first >= last
      return arr
    end

    # Partition
    index = partition(arr, first, last)

    # Sort one half
    quicksort(arr, first, index - 1)

    # Sort the other
    quicksort(arr, index + 1, last)
  end

  def partition(arr, first, last)
    # Set pivot to last element
    pivot = arr[last]
    index = first

    for counter in (index...last) do
      if arr[counter] <= pivot
        # Swap index and counter
        tmp = arr[index]
        arr[index] = arr[counter]
        arr[counter] = tmp
        index += 1
      end
    end

    # Swap pivot with index
    tmp = arr[index]
    arr[index] = arr[last]
    arr[last] = tmp

    index
  end

  def list
    @arr.join(", ")
  end
end
