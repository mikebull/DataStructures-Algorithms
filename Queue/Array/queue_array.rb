class QueueArray
  def initialize(size = 10)
    @arr = Array.new(size)
    @size = size
    @front = -1
    @rear = 0
  end

  def enqueue(value)
    if @front.eql?(-1)
      @front = 0
      @arr[@front] = value
      return
    end

    next_node = @rear + 1

    if next_node >= @size
      @rear = next_node = 0
    end

    @arr[next_node] = value
    @rear = next_node
  end

  def dequeue
    @arr[@front] = nil

    if @front.eql?(@size-1)
      if @arr[0].nil?
        @front = 0
      else
        throw "Full"
      end
    else
      @front += 1
    end
  end

  def empty?
    @front.eql?(-1)
  end

  def peek
    @arr[@front]
  end

  def list
    puts @arr.join(', ')
  end

  def size
    @size
  end
end