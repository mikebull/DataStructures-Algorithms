require_relative 'queue_linked_list'

queue = QueueLinkedList.new

queue.list
puts "There are #{queue.size} elements in the list" 

queue.enqueue(1)
queue.enqueue(2)
queue.enqueue(3)
queue.enqueue(4)
queue.enqueue(5)

queue.list
puts "There are #{queue.size} elements in the list"

queue.dequeue
queue.dequeue
queue.dequeue

queue.list
puts "There are #{queue.size} elements in the list"

queue.dequeue
queue.dequeue

queue.list
puts "There are #{queue.size} elements in the list"

puts "The queue is empty" if queue.empty?
