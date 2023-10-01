import math
import sys

def get_Correct_K(promt):
    while (True):
        print(promt)
        K_String = input()
        try:
            K = float(K_String)
        except:
            print("Введен некорректный коэффициент. Попробуйте еще раз!")
        else:
            return K

def get_K(index, promt):
    try:
        K_String = sys.argv[index]
    except:
        print(promt)
        K_String = input()
    try:
        K = float(K_String)
    except:
        print("Введен некорректный коэффициент. Попробуйте еще раз!")
        K = get_Correct_K(promt)

    while K == 0 and index == 1:
        print("Коэффициент A не должен равняться 0. Введите новый коэффициент!")
        K = get_Correct_K(promt)
    return K
        
def get_roots(a, b, c):
    result = []
    D = b*b - 4*a*c
    if D == 0.0:
        root = -b / (2.0*a)
        result.append(root)
    elif D > 0.0:
        sqD = math.sqrt(D)
        root1 = (-b + sqD) / (2.0*a)
        root2 = (-b - sqD) / (2.0*a)
        result.append(root1)
        result.append(root2)
    return result


def main():
    a = get_K(1, 'Введите коэффициент А:')
    b = get_K(2, 'Введите коэффициент B:')
    c = get_K(3, 'Введите коэффициент C:')
    roots = get_roots(a,b,c)
    len_roots = len(roots)
    if len_roots == 0:
        print('Нет корней')
    elif len_roots == 1:
        print('Один корень: {}'.format(roots[0]))
    elif len_roots == 2:
        print('Два корня: {} и {}'.format(roots[0], roots[1]))
    

if __name__ == "__main__":
    main()
