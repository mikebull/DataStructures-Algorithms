class MaxHeap
  def initialize(max_size=20)
    @max_size = max_size
    @heap = Array.new(max_size)
    @pointer = 0
  end

  def insert(value)
    # Add element to next leaf node
    @heap[@pointer] = value

    sift_up(@pointer)

    puts "Added #{value} at #{@pointer} - #{list}"

    @pointer += 1
  end

  def sift_up(index)
    parent_node_index = ((index-1) / 2).floor

    if index > 0 && @heap[parent_node_index] < @heap[index]
      tmp = @heap[index]
      @heap[index] = @heap[parent_node_index]
      @heap[parent_node_index] = tmp
      sift_up(parent_node_index)
    end
  end

  def get_max
    @heap[0]
  end

  def get_size; end

  def empty?
    @heap.empty?
  end

  def extract_max
    # Swap max node with leaf
    max = @heap[0]
    @heap[0] = @heap[@pointer]
    remove(@pointer)

    max
  end

  def sift_down(index)
    node = @heap[index]
    
    left_index = (2 * index) + 1
    right_index = (2 * index) + 2

    puts "Node: #{@heap[index]}. Left child: #{@heap[left_index]}. Right Child: #{@heap[right_index]}"

    child = left_index < size && @heap[left_index] <= @heap[right_index] ? left_index : right_index

    if child < size && @heap[child] > node
      tmp = node
      @heap[index] = @heap[child]
      @heap[child] = tmp

      sift_down(child)
    end
  end

  def remove(value)
    # Swap element with last leaf
    index = @heap.index(value)
    
    @heap[index] = @heap[@pointer]
    @heap[@pointer] = nil

    @pointer -= 1
    
    sift_up(index)
    sift_down(index)
  end

  def list
    @heap.compact.join(",")
  end

  def heapify; end

  def heap_sort; end
end
