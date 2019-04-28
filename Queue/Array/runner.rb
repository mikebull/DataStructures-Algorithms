require_relative "queue_array"

queue = QueueArray.new(5)

queue.enqueue(1)
queue.enqueue(2)
queue.enqueue(3)
queue.enqueue(4)
queue.enqueue(5)

queue.list

queue.dequeue

queue.enqueue(6)

queue.list
