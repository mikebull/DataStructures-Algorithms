class Deque
  def initialize(size = 10)
    @arr = Array.new(size)
    @size = size
    @front = -1
    @rear = 0
  end

  def enqueue_front; end
  def enqueue_rear; end
  def dequeue_front; end
  def dequeue_rear; end
  def peek_front; end
  def peek_rear; end
  def empty?; end
  def full?; end
end
