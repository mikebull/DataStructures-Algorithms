class InsertionSort
  def initialize(arr)
    @arr = arr.shuffle
  end

  def sort
    for i in (1...@arr.length)
      pointer = i
      while @arr[pointer] < @arr[pointer - 1] && pointer > 0
        tmp = @arr[pointer]
        @arr[pointer] = @arr[pointer - 1]
        @arr[pointer - 1] = tmp

        pointer -= 1
      end
    end
  end

  def list
    @arr.join(", ")
  end
end
