require_relative 'merge_sort'

obj = MergeSort.new([5, 2, 8, 3, 9, 7, 1, 4, 0, 6])

puts "Unsorted List: #{obj.list}"

test = obj.sort

puts "Sorted List: #{obj.list}"