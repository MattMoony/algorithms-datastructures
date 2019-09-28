class LinkedListNode(object):
    def __init__(self, value, prev=None, aftr=None):
        self.value = value
        self.prev = prev
        self.aftr = aftr

class LinkedList(object):
    def __init__(self):
        self.__start = None
        self.__end = None
        self.__length = 0

    def size(self):
        return self.__length

    def append(self, value):
        if self.__length == 0:
            n = LinkedListNode(value)
            self.__start = n
        else:
            n = LinkedListNode(value, self.__end)
            self.__end.aftr = n
        
        self.__end = n
        self.__length += 1
        
    def insert(self, value, index):
        if index < 0 or index > self.__length:
            raise IndexError()
        elif index == self.__length:
            self.append(value)
        else:
            if index == 0:
                n = LinkedListNode(value, None, self.__start)
                self.__start.prev = n
                self.__start = n
            else:
                trgt = self.get_node(index)
                n = LinkedListNode(value, trgt.prev, trgt)
                trgt.prev.aftr = n
                trgt.prev = n
                
        self.__length += 1

    def get_node(self, index):
        if index >= self.__length:
            raise IndexError()
        else:
            cu = self.__start
            for i in range(index):
                cu = cu.aftr
            return cu

    def first():
        return start

    def last():
        return end

    def get(self, index):
        try:
            return self.get_node(index).value
        except IndexError:
            raise IndexError()
        
    def remove(self, index):
        el = self.get_node(index)
        
        if el == self.__start:
            self.__start = self.__start.aftr
            self.__start.prev = None
        else:
            el.prev.aftr = el.aftr
            el.aftr.prev = el.prev
            
            if el == self.__end:
                self.__end = el.prev
        
        self.__length -= 1
        
    def __str__(self):
        ret = 'LinkedList{ '
        
        if self.__length > 16:
            for i in range(8):
                ret += str(self.get(i)) + ', '

            ret += '..., '
            
            for i in range(self.__length-8,self.__length):
                ret += str(self.get(i))
                ret += ' }' if i == self.__length - 1 else ', '
        else:
            for i in range(self.__length):
                ret += str(self.get(i))
                ret += ' }' if i == self.__length - 1 else ', '
                
        return ret

def main():
    lli = LinkedList()
    
    for i in range(32):
        lli.append(i)

    print(lli)

    lli.remove(0)
    lli.remove(1)

    print(lli)

    lli.insert(8, 1)
    
    print(lli)
    
if __name__ == '__main__':
    main()