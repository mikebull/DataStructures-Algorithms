require_relative "node"

class SingleLinkedList
  def initialize(head)
    @head = Node.new(head)
  end

  def size
    return 0 if @head.nil?

    length = 0
    node = @head

    while !node.nil?
      length += 1
      node = node.next
    end

    length
  end

  def empty?
    @head.nil?
  end

  def value_at(index)
    counter = 0

    node = @head

    return -1 if node.nil?

    while !node.nil?
      return node if counter.eql?(index)
    end

    return -1
  end

  def push_front(value)
    tmp = @head

    @head = Node.new(value, tmp)
  end

  def pop_front()
    tmp = @head.next

    @head = tmp
  end

  def push_back(value)
    node = @head

    while !node.next.nil?
      node = node.next
    end

    node.next = Node.new(value)
  end

  def pop_back()
    node = @head

    while !node.next.next.nil?
      node = node.next
    end

    node.next = nil
  end
  
  def front
    @head.value
  end
  
  def back
    node = @head

    while !node.next.nil?
      node = node.next
    end

    node.value
  end

  def insert(index, value)
    counter = 0

    node = @head

    while !node.nil? || !counter.eql?(index)
      node = node.next
      counter += 1
    end

    return -1 if node.nil?

    if node.next.nil?
      node.next = Node.new(value)
    else
      right_node = node.next
      node.next = Node.new(value, right_node)
    end
  end

  def erase(index)
    counter = 0

    node = @head

    if index.eql?(0)
      @head = @head.next
      return
    end

    while !node.nil? || !counter.eql?(index - 1)
      node = node.next
      counter += 1
    end

    return unless counter.eql?(index - 1)

    node.next = node.next.next
  end

  def value_n_from_end(n)
   counter = 0

   node = @head

   while !node.nil?
    node = node.next
    counter += 1
   end

   counter -= n

   node = @head

   while !counter.eql?(0)
    node = node.next
   end

   node.next = node.next.next
  end
  
  def reverse()
    stack = []

    node = @head

    while !node.nil?
      stack.push(node.value)
      node = node.next
    end

    @head = Node.new(stack.pop)

    node = @head

    while !stack.empty?
      value = stack.pop
      node.next = Node.new(value)
      node = node.next
    end
  end
  
  def remove_value(value); end

  def print_list
    node = @head
    arr = []

    while !node.nil?
      arr << node.value
      node = node.next
    end

    puts arr.join(", ")
  end
end