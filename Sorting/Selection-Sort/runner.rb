require_relative 'selection_sort'

obj = SelectionSort.new([5, 2, 8, 3, 9, 7, 1, 4, 0, 6])

puts "Unsorted List: #{obj.list}"

obj.sort

puts "Sorted List: #{obj.list}"