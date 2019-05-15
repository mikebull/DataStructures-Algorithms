require_relative 'Single/linked_list.rb'

list = SingleLinkedList.new(1)

list.size

list.push_front(0)

list.push_back(2)
list.push_back(3)
list.push_back(4)
list.push_back(5)

puts list.print_list

list.reverse

puts list.print_list