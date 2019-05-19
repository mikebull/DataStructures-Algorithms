class SelectionSort
  def initialize(arr)
    @arr = arr.shuffle
  end

  def sort
    counter = 0
    # Set pointer for sorted side of array
    for i in (0...@arr.length) do
      # Find minimum value
      min_index = i
      for j in (i...@arr.length)
        min_index = j if @arr[j] < @arr[min_index]
      end
      # Put item in ith position
      tmp = @arr[min_index]
      @arr[min_index] = @arr[i]
      @arr[i] = tmp
    end
  end

  def list
    @arr.join(", ")
  end
end
