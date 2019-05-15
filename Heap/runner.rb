require_relative 'max_heap'

heap = MaxHeap.new

heap.insert(29)
heap.insert(15)
heap.insert(38)
heap.insert(50)
heap.insert(40)
heap.insert(20)
heap.insert(37)
heap.insert(11)

puts "Max is #{heap.get_max}"
puts "Final Heap: #{heap.list}"