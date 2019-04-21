require_relative 'hash_table'

hash = HashTable.new

hash.add(1, "One")
hash.add(2, "Two")
hash.add(4, "Four")
hash.add(3, "Three")
hash.add(5, "Five")
hash.add(6, 6)
hash.add(7, 7)
hash.add(8, 8)
hash.add(8, 9)
hash.add(10, 10)

puts hash.exists?(5)
puts hash.exists?(8)

hash.list

value = hash.get(3)
puts value

hash.remove(3)

puts hash.exists?(3)