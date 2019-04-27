require_relative 'node'

class QueueLinkedList
  attr_accessor :head, :tail, :size

  def initialize
    @size = 0
  end

  def enqueue(value)
    if empty?
      @head = Node.new(value)
    elsif @tail.nil?
      @tail = Node.new(value)
      @head.next = @tail
    else
      tempNode = @tail
      @tail = Node.new(value)
      tempNode.next = @tail      
    end

    @size += 1
  end

  def dequeue
    return nil if empty?

    node = @head
    
    if @tail.nil?
      @head = nil
    else
      next_node = @head.next
      @head = next_node
    end
    
    @size -= 1
  end

  def empty?
    @head.nil?
  end

  def peek
    return nil if empty?

    return @head.value
  end

  def list
    if empty?
      puts "[]"
    elsif @tail.nil?
      puts "[#{@head.value}]" 
    else
      print "["
      next_node = @head
      while !next_node.nil?
        print next_node.value
        print "," unless next_node.next.nil?
        next_node = next_node.next
      end
      print "]\n"
    end
  end

  def size
    @size
  end
end