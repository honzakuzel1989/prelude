using System.Collections.Generic;

namespace System.Prelude
{
    /// <summary>
    /// The analogy for part of basic function library from my favorite functional language
    /// <see ref="http://www.cse.chalmers.se/edu/course/TDA555/tourofprelude.html"/>
    /// </summary>
    public static class Prelude
    {
        /// <summary>
        /// Applied to a list of integer numbers, returns their product. 
        /// </summary>
        public static int Product(this IEnumerable<int> xs)
        {
            return (int)Product(Map(xs, a => (double)a));
        }

        /// <summary>
        /// Applied to a list of double numbers, returns their product. 
        /// </summary>
        public static double Product(this IEnumerable<double> xs)
        {
            // product xs = foldl (*) 1 xs
            return Foldl(xs, (a, b) => a * b, 1.0);
        }

        /// <summary>
        /// Returns the absolute value of a integer number. 
        /// </summary>
        public static int Abs(this int x)
        {
            return (int)Abs((double)x); 
        }

        /// <summary>
        /// Returns the absolute value of a real number. 
        /// </summary>
        public static double Abs(this double x)
        {
            // abs x
            //   | x >= 0 = x
            //   | otherwise = -x
            return x >= 0 ? x : -x;
        }

        /// <summary>
        /// Given a function, and a list of any type, returns a list where each element is the result of applying the function to the corresponding element in the input list.
        /// </summary>
        public static IEnumerable<B> Map<A, B>(this IEnumerable<A> xs, Func<A, B> f)
        {
            // map f xs = [f x | x <- xs]
            foreach (var x in xs) yield return f(x);   
        }

        /// <summary>
        /// Folds up a list, using a given binary operator and a given start value, in a right associative manner.
        /// </summary>
        public static B Foldr<A, B>(this IEnumerable<A> xs, Func<A, B, B> f, B b)
        {
            // foldr f z [] = z
            // foldr f z (x:xs) = f x (foldr f z xs)
            if(IsEmpty(xs)) return b; else return f(Head(xs), Foldr(xs.Tail(), f, b));
        }

        /// <summary>
        /// Folds right over non--empty lists. 
        /// </summary>
        public static A Foldr1<A>(this IEnumerable<A> xs, Func<A, A, A> f)
        {
            // foldr1 f [x] = x
            // foldr1 f (x:xs) = f x (foldr1 f xs)
            if(!IsLongestThan(xs, 1)) return Head(xs); else return f(Head(xs), Foldr1(xs.Tail(), f));
        }

        /// <summary>
        /// Folds up a list, using a given binary operator and a given start value, in a left associative manner. 
        /// </summary>
        public static A Foldl<A, B>(this IEnumerable<B> xs, Func<A, B, A> f, A a)
        {
            // foldl f z [] = z
            // foldl f z (x:xs) = foldl f (f z x) xs
            if(IsEmpty(xs)) return a; else return Foldl(Tail(xs), f, f(a, Head(xs)));
        }

        /// <summary>
        /// Folds left over non--empty lists. 
        /// </summary>
        public static A Foldl1<A>(this IEnumerable<A> xs, Func<A, A, A> f)
        {
            // foldl1 f (x:xs) = foldl f x xs
            return Foldl(Tail(xs), f, Head(xs));
        }

        /// <summary>
        /// Returns the first element of a non--empty list. If applied to an empty list an error results.
        /// </summary>
        public static A Head<A>(this IEnumerable<A> xs)
        {
            // head (x:_) = x
            foreach (var x in xs) return x;
            throw new PreludeException("Head: empty list");
        }

        /// <summary>
        /// Applied to a non--empty list, returns the list without its first element.
        /// </summary>
        public static IEnumerable<A> Tail<A>(this IEnumerable<A> xs)
        {
            // tail (_:xs) = xs
            int cnt = 0;
            foreach (var x in xs) if (++cnt > 1)  yield return x;
            if(cnt < 1) throw new PreludeException("Tail: empty list");
        }

        /// <summary>
        /// Applied to a predicate and a list, returns True if all elements of the list satisfy the predicate, and False otherwise. Similar to the function any.
        /// </summary>
        public static bool All<A>(this IEnumerable<A> xs, Func<A, bool> f)
        {
            // all p xs = and (map p xs)
            return And(Map(xs, f));
        }
        
        /// <summary>
        /// Takes the logical conjunction of a list of boolean values (see also or).
        /// </summary>
        public static bool And(this IEnumerable<bool> xs)
        {
            // and xs = foldr (&&) True xs
            return Foldr(xs, (a, b) => a && b, true);
        }

        /// <summary>
        /// Applied to a list of boolean values, returns their logical disjunction (see also and).
        /// </summary>
        public static bool Or(this IEnumerable<bool> xs)
        {
            // or xs = foldr (||) False xs
            return Foldr(xs, (a, b) => a || b, false);
        }

        /// <summary>
        /// Applied to an integer in the range 0 -- 255, returns the character whose ascii code is that integer. It is the converse of the function ord. 
        /// </summary>
        public static char Chr(this int ord)
        {
            return (char)ord;
        }

        /// <summary>
        /// Applied to a character, returns its ascii code as an integer.
        /// </summary>
        public static int Ord(this char chr)
        {
            return (int)chr;
        }

        /// <summary>
        /// Given a predicate and a list, breaks the list into two lists (returned as a tuple) at the point where the predicate is first satisfied. If the predicate is never satisfied then the first element of the resulting tuple is the entire list and the second element is the empty list ([]).
        /// </summary>
        public static (IEnumerable<A>, IEnumerable<A>) Break<A>(this IEnumerable<A> xs, Func<A, bool> p)
        {
            // break p xs = span p' xs where p' x = not (p x)
            return Span(xs, x => Not(p(x)));
        }

        /// <summary>
        /// Given a predicate and a list, splits the list into two lists (returned as a tuple) such that elements in the first list are taken from the head of the list while the predicate is satisfied, and elements in the second list are the remaining elements from the list once the predicate is not satisfied.
        /// </summary>
        public static (IEnumerable<A>, IEnumerable<A>) Span<A>(this IEnumerable<A> xs, Func<A, bool> p)
        {
            // span p [] = ([],[])
            // span p xs@(x:xs')
            // | p x = (x:ys, zs)
            // | otherwise = ([],xs)
            // where (ys,zs) = span p x
            int skip = 0;
            var satisfied = new List<A>();
            foreach (var x in xs)
            {
                if(p(x)) { satisfied.Add(x); skip++; }
                else return (satisfied, Skip(xs, skip));
            }
            return (satisfied, Empty<A>());
        }

        /// <summary>
        ///  Applied to a list of lists, joins them together using the ++ operator. 
        /// </summary>
        public static IEnumerable<A> Concat<A>(this IEnumerable<IEnumerable<A>> xs)
        {
            // concat xs = foldr (++) [] xs
            return Foldr<IEnumerable<A>, IEnumerable<A>>(xs, Concat, Empty<A>());
        }

        /// <summary>
        /// Given a function which maps a value to a list, and a list of elements of the same type as the value, applies the function to the list and then concatenates the result (thus flattening the resulting list). 
        /// </summary>
        public static IEnumerable<B> ConcatMap<A, B>(this IEnumerable<A> xs, Func<A, IEnumerable<B>> f)
        {
            // concatMap f = concat . map f
            return Concat(Map(xs, f));
        }

        /// <summary>
        /// Creates a constant valued function which always has the value of its first argument, regardless of the value of its second argument. 
        /// </summary>
        public static A Const<A, B>(this A a, B b) 
        {
            return a;
        }

        /// <summary>
        /// Returns the logical negation of its boolean argument.
        /// </summary>
        public static bool Not(this bool b)
        {
            // not True = False
            // not False = True
            return !b;
        }

        /// <summary>
        /// Converts a digit character into the corresponding integer value of the digit. [Import from Data.Char] 
        /// </summary>
        public static int DigitToInt(this char c) 
        {
            // digitToInt c
            // | isDigit c            =  fromEnum c - fromEnum '0'
            // | c >= 'a' && c <= 'f' =  fromEnum c - fromEnum 'a' + 10
            // | c >= 'A' && c <= 'F' =  fromEnum c - fromEnum 'A' + 10
            // | otherwise            =  error "Char.digitToInt: not a digit"
            return IsDigit(c) ? c - '0' : 
                ((c >= 'a' && c <= 'f') ? c - 'a' + 10 : 
                ((c >= 'A' && c <= 'F') ? c - 'A' + 10 : 
                throw new PreludeException("DigitToInt: not a digit")));
        }

        /// <summary>
        /// Applied to a number and a list, returns the list with the specified number of elements removed from the front of the list. If the list has less than the required number of elements then it returns []. 
        /// </summary>
        public static IEnumerable<A> Drop<A>(this IEnumerable<A> xs, int n)
        {
            // drop 0 xs            = xs
            // drop _ []            = []
            // drop n (_:xs) | n>0  = drop (n-1) xs
            // drop _ _             = error "PreludeList.drop: negative argument"
            if(n == 0) return xs;
            if(IsEmpty(xs)) return new A[]{};
            if(n > 0) return Skip(xs, n);
            throw new PreludeException("Drop: negative argument");
        }

        /// <summary>
        /// The ratio of the circumference of a circle to its diameter. 
        /// </summary>
        public static double PI()
        {
            return System.Math.PI;
        }

        /// <summary>
        /// Applied to an integral argument, returns True if the argument is even, and False otherwise. 
        /// </summary>
        public static bool Even(this int n)
        {
            // even n = n `rem` 2 == 0
            return Mod(n, 2) == 0;
        }

        /// <summary>
        /// Applied to an integral argument, returns True if the argument is odd, and False otherwise. 
        /// </summary>
        public static bool Odd(this int n)
        {
            // odd = not . even
            return Not(Even(n));
        }

        /// <summary>
        /// Applied to a predicate and a list, removes elements from the front of the list while the predicate is satisfied. 
        /// </summary>
        public static IEnumerable<A> DropWhile<A>(this IEnumerable<A> xs, Func<A, bool> p)
        {
            // dropWhile p [] = []
            // dropWhile p (x:xs)
            // | p x = dropWhile p xs
            // | otherwise = (x:xs)
            bool take = true;
            foreach (var x in xs)
            {
                if(take && p(x)) continue; 
                else
                {
                    take = false;
                    yield return x;
                }
            }
        }

        /// <summary>
        /// Applied to a value and a list returns True if the value is in the list and False otherwise. The elements of the list must be of the same type as the value. 
        /// </summary>
        public static bool Elem<A>(this A x, IEnumerable<A> xs)
        {
            // elem x xs = any (== x) xs
            return Any(xs, (s) => s.Equals(x));
        }

        /// <summary>
        /// Applied to a predicate and a list, returns True if any of the elements of the list satisfy the predicate, and False otherwise. Similar to the function all. 
        /// </summary>
        public static bool Any<A>(this IEnumerable<A> xs, Func<A, bool> p)
        {
            // any p xs = or (map p xs)
            return Or(Map(xs, p));
        }

        /// <summary>
        /// Applied to a predicate and a list, returns a list containing all the elements from the argument list that satisfy the predicate. 
        /// </summary>
        public static IEnumerable<A> Filter<A>(this IEnumerable<A> xs, Func<A, bool> p)
        {
            // filter p xs = [k | k <- xs, p k]
            foreach (var x in xs) if(p(x)) yield return x;
        }

        /// <summary>
        /// Applied to a binary function, returns the same function with the order of the arguments reversed. 
        /// </summary>
        public static C Flip<A, B, C>(this Func<A, B, C> f, B x, A y)
        {
            // flip f x y = f y x            
            return f(y, x);
        }

        /// <summary>
        /// Returns the first element of a two element tuple. 
        /// </summary>
        public static A Fst<A, B>(this (A fst, B snd) a)
        {
            // fst (x, _) = x
            return a.fst;
        }

        /// <summary>
        /// Returns the second element of a two element tuple. 
        /// </summary>
        public static B Snd<A, B>(this (A fst, B snd) a)
        {
            // snd (_, y) = y
            return a.snd;
        }

        /// <summary>
        /// Returns the greatest common divisor between its two integral arguments. 
        /// </summary>
        public static int GCD(this int x, int y)
        {
            // gcd 0 0 = error "Prelude.gcd: gcd 0 0 is undefined"
            // gcd x y = gcd' (abs x) (abs y)
            //         where
            //             gcd' x 0 = x
            //             gcd' x y = gcd' y (x `rem` y)
            if(x ==0 && y == 0) throw new PreludeException("GCD: gcd 0 0 is undefined");
            if(y == 0) return x;
            return GCD(Abs(y), Abs(Mod(x, y)));
        }

        /// <summary>
        /// The identity function, returns the value of its argument. 
        /// </summary>
        public static A ID<A>(this A x)
        {
            // id x = x
            return x;
        }

        /// <summary>
        /// Returns all but the last element of its argument list. The argument list must have at least one element. If init is applied to an empty list an error occurs. 
        /// </summary>
        public static IEnumerable<A> Init<A>(this IEnumerable<A> xxs)
        {
            // init [x] = []
            // init (x:xs) = x : init xs
            if(!IsLongestThan(xxs, 1)) return Empty<A>(); else return AppendFront(Head(xxs), Init(Tail(xxs)));
        }

        /// <summary>
        /// Iterate~f~x returns the infinite list [x,~f(x),~f(f(x)),~...]. 
        /// </summary>
        public static IEnumerable<A> Iterate<A>(this A x, Func<A, A> f)
        {
            // iterate f x = x : iterate f (f x)
            yield return x;
            foreach (var xx in Iterate(f(x), f))
                yield return xx;
        }

        /// <summary>
        /// Applied to a non--empty list, returns the last element of the list. 
        /// </summary>
        public static A Last<A>(this IEnumerable<A> xxs)
        {
            // last [x] = x
            // last (_:xs) = last xs
            return !IsLongestThan(xxs, 1) ? Head(xxs) : Last(Tail(xxs));
        }

        /// <summary>
        /// Returns the least common multiple of its two integral arguments. 
        /// </summary>
        public static int LCM(this int x, int y)
        {
            // lcm _ 0 = 0
            // lcm 0 _ = 0
            // lcm x y = abs ((x `quot` gcd x y) * y)
            return (x == 0 || y == 0) ? 0 : Abs((x / GCD(x, y) * y));
        }

        /// <summary>
        /// Returns the number of elements in a finite list. 
        /// </summary>
        public static int Length<A>(this IEnumerable<A> xxs)
        {
            // length [] = 0
            // length (x:xs) = 1 + length xs
            if(IsEmpty(xxs)) return 0;
            return 1 + Length(Tail(xxs));
        }

        /// <summary>
        /// Applied to a list of characters containing newlines, returns a list of lists by breaking the original list into lines using the newline character as a delimiter. The newline characters are removed from the result. 
        /// </summary>
        public static IEnumerable<string> Lines(this string xxs)
        {
            // lines [] = []
            // lines (x:xs)
            // = l : ls
            // where
            // (l, xs') = break (== '\n') (x:xs)
            // ls
            //     | xs' == [] = []
            //     | otherwise = lines (tail xs')
            if(IsEmpty(xxs)) yield break;

            var (l, xs) = Break(xxs, c => c == '\n');
            yield return string.Concat(l);

            if(IsEmpty(xs)) yield break;
            else 
            {
                foreach (var ll in Lines(string.Concat(Tail(xs))))
                    yield return ll;
            }
        }

        /// <summary>
        ///  Applied to two values of the same type which have an ordering defined upon them, returns the maximum of the two elements according to the operator >=. 
        /// </summary>
        public static A Max<A>(this A x, A y) where A : IComparable<A>
        {
            // max x y
            // | x >= y = x
            // | otherwise = y
            return x.CompareTo(y) > 0 ? x : y;
        }

        /// <summary>
        /// Applied to two values of the same type which have an ordering defined upon them, returns the minimum of the two elements according to the operator <=. 
        /// </summary>
        public static A Min<A>(this A x, A y) where A : IComparable<A>
        {
            // min x y
            // | x <= y = x
            // | otherwise = y
            return x.CompareTo(y) > 0 ? y : x;
        }

        /// <summary>
        /// Applied to a non--empty list whose elements have an ordering defined upon them, returns the minimum element of the list. 
        /// </summary>
        public static A Minimum<A>(this IEnumerable<A> xs) where A : IComparable<A>
        {
            // maximum xs = foldl1 max xs
            return Foldl1(xs, Min);
        }

        /// <summary>
        /// Applied to a non--empty list whose elements have an ordering defined upon them, returns the maximum element of the list. 
        /// </summary>
        public static A Maximum<A>(this IEnumerable<A> xs) where A : IComparable<A>
        {
            // minimum xs = foldl1 min xs
            return Foldl1(xs, Max);
        }

        /// <summary>
        /// Returns True if its first argument is not an element of the list as its second argument. 
        /// </summary>
        public static bool NotElem<A>(this A x, IEnumerable<A> xs)
        {
            return Not(Elem(x, xs));
        }

        /// <summary>
        /// Returns True if its argument is the empty list ([]) and False otherwise. 
        /// </summary>
        public static bool Null<A>(this IEnumerable<A> xs)
        {
            // null [] = True
            // null (_:_) = False
            return IsEmpty(xs);
        }

        /// <summary>
        /// Given a value, returns an infinite list of elements the same as the value. 
        /// </summary>
        public static IEnumerable<A> Repeat<A>(this A x)
        {
            // repeat x
            // = xs
            // where xs = x:xs
            while(true) yield return x;
        }

        /// <summary>
        /// Given an integer (positive or zero) and a value, returns a list containing the specified number of instances of that value. 
        /// </summary>
        public static IEnumerable<A> Replicate<A>(this A x, int n)
        {
            // replicate n x = take n (repeat x)
            return Take(Repeat(x), n);
        }

        /// <summary>
        /// Applied to an integer (positive or zero) and a list, returns the specified number of elements from the front of the list. If the list has less than the required number of elements, take returns the entire list. 
        /// </summary>
        public static IEnumerable<A> Take<A>(this IEnumerable<A> xs, int n)
        {
            // take 0 _ = []
            // take _ []= []
            // take n (x:xs)
            // | n > 0 = x : take (n-1) xs
            // take _ _ = error "PreludeList.take: negative argument"
            if(n == 0) return Empty<A>();
            else if(IsEmpty(xs)) return Empty<A>();
            else if(n > 0) return AppendFront(Head(xs), Take(Tail(xs), n - 1));
            throw new PreludeException("Take: negative argument");
        }

        /// <summary>
        /// Applied to a predicate and a list, returns a list containing elements from the front of the list while the predicate is satisfied.
        /// </summary>
        public static IEnumerable<A> TakeWhile<A>(this IEnumerable<A> xs, Func<A, bool> p)
        {   	
            // takeWhile p [] = []
            // takeWhile p (x:xs)
            // | p x = x : takeWhile p xs
            // | otherwise = []
            foreach (var x in xs) if(p(x)) yield return x; else break;
        }

        /// <summary>
        /// Given an integer (positive or zero) and a value, returns a list containing the specified number of instances of that value. 
        /// </summary>
        public static IEnumerable<A> Reverse<A>(this IEnumerable<A> xs)
        {
            // reverse = foldl (flip (:)) []
            return Foldl(xs, (x, y) => Flip(AppendFront, x, y) , Empty<A>());
        }

        /// <summary>
        /// Converts a value, to its string representation. 
        /// </summary>
        public static string Show<A>(this A x)
        {
            // defined internally
            return x.ToString();
        }

        /// <summary>
        /// Sorts its argument list in ascending order. The items in the list must be in the class Ord. [Import from Data.List] 
        /// </summary>
        public static IEnumerable<A> Sort<A>(this IEnumerable<A> xs)
        {
            var len = xs.Length();
            var xsa = new A[len];

            // Copy array
            int cnt = 0;
            foreach (var x in xs)
                xsa[cnt++] = x;

            // Sort array in ascending order - Quicksort algorithm.
            Array.Sort(xsa);
            return xsa;
        }

        /// <summary>
        /// Given an integer (positive or zero) and a list, splits the list into two lists (returned as a tuple) at the position corresponding to the given integer. If the integer is greater than the length of the list, it returns a tuple containing the entire list as its first element and the empty list as its second element. 
        /// </summary>
        public static (IEnumerable<A>, IEnumerable<A>) SplitAt<A>(this IEnumerable<A> xs, int n)
        {
            // splitAt 0 xs = ([],xs)
            // splitAt _ [] = ([],[])
            // splitAt n (x:xs)
            // | n > 0 = (x:xs',xs'')
            //     where
            //     (xs',xs'') = splitAt (n-1) xs
            // splitAt _ _ = error "PreludeList.splitAt: negative argument"
            if(n == 0) return (Empty<A>(), xs);
            else if(IsEmpty(xs)) return (Empty<A>(), Empty<A>());
            else if(n > 0)
            {
                // (xs',xs'') = splitAt (n-1) xs
                var (xs1, xs2) =  SplitAt(Tail(xs), n - 1);
                // (x:xs',xs'')
                return (AppendFront(Head(xs), xs1), xs2);
            }
            else throw new PreludeException("SplitAt: negative argument");
        }

        /// <summary>
        /// Converts an uppercase alphabetic character to a lowercase alphabetic character. If this function is applied to an argument which is not uppercase the result will be the same as the argument unchanged. [Import from Data.Char]
        /// </summary>
        public static char ToLower(this char c)
        {
            // toLower c
            //   | isUpper c = toEnum (fromEnum c - fromEnum 'A' + fromEnum 'a')
            //   | otherwise = c
            return IsUpper(c) ? (char)(c - 'A' + 'a') : c;
        }

        /// <summary>
        /// Applied to a character argument, returns True if the character is a lower case alphabetic, and False otherwise. [Import from Data.Char]
        /// </summary>
        public static bool IsLower(this char c)
        {
            // isLower c = c >= 'a' && c <= 'z'
            return c >= 'a' && c <= 'z';
        }

        /// <summary>
        /// Converts a lowercase alphabetic character to an uppercase alphabetic character. If this function is applied to an argument which is not lowercase the result will be the same as the argument unchanged. [Import from Data.Char]
        /// </summary>
        public static char ToUpper(this char c)
        {
            // toUpper c
            //   | isLower c = toEnum (fromEnum c - fromEnum 'a' + fromEnum 'A')
            //   | otherwise = ctoUpper c  
            return IsLower(c) ? (char)(c - 'a' + 'A') : c;
        }

        /// <summary>
        /// Applied to a character argument, returns True if the character is an upper case alphabetic, and False otherwise. [Import from Data.Char]
        /// </summary>
        public static bool IsUpper(this char c)
        {
            // isUpper c = c >= 'A' && c <= 'Z'
            return c >= 'A' && c <= 'Z';
        }

        /// <summary>
        /// Converts a list of strings into a single string, placing a newline character between each of them. It is the converse of the function lines.
        /// </summary>
        public static string Unlines(this IEnumerable<string> xs)
        {
            // unlines xs
            // = concat (map addNewLine xs)
            // where
            // addNewLine l = l ++ "\n"
            return string.Concat(Concat(Map(xs, a => a + '\n')));
        }

        /// <summary>
        /// Given a predicate, a unary function and a value, it recursively re--applies the function to the value until the predicate is satisfied. If the predicate is never satisfied until will not terminate. 
        /// </summary>
        public static A Until<A>(this A x, Func<A, bool> p, Func<A, A> f)
        {
            // until p f x
            //   | p x = x
            //   | otheriwise = until p f (f x)
            return p(x) ? x : Until(f(x), p, f);
        }

        /// <summary>
        /// Concatenates a list of strings into a single string, placing a single space between each of them. 
        /// </summary>
        public static string Unwords(this IEnumerable<string> xs)
        {
            // unwords [] = []
            // unwords ws
            //   = foldr1 addSpace ws
            //   where
            //   addSpace w s = w ++ (' ':s)
            return IsEmpty(xs) ? string.Empty : Foldr1(xs, (w, s) => w + ' ' + s);
        }

        /// <summary>
        /// Breaks its argument string into a list of words such that each word is delimited by one or more whitespace characters. 
        /// </summary>
        public static IEnumerable<string> Words(this string s)
        {
            // words s
            //   | findSpace == [] = []
            //   | otherwise = w : words s''
            //   where
            //   (w, s'') = break isSpace findSpace
            //   findSpace = dropWhile isSpace s
            Func<string, IEnumerable<char>> findSpace = x => DropWhile(x, IsSpace);
            if(IsEmpty(findSpace(s))) return Empty<string>();
            else
            {
                var (w, s2) = Break(findSpace(s), IsSpace);
                return AppendFront(string.Concat(w), Words(string.Concat(s2)));
            }
        }

        /// <summary>
        /// Returns True if its character argument is a whitespace character and False otherwise. [Import from Data.Char] 
        /// </summary>
        public static bool IsSpace(this char c)
        {
            // isSpace c  = c == ' '  || c == '\t' || c == '\n' ||
            //              c == '\r' || c == '\f' || c == '\v'
            return c == ' '  || c == '\t' || c == '\n' || c == '\r' || c == '\f' || c == '\v';
        }

        /// <summary>
        /// Applied to a binary function and two lists, returns a list containing elements formed be applying the function to corresponding elements in the lists. 
        /// </summary>
        public static IEnumerable<C> ZipWith<A, B, C>(this IEnumerable<A> a, IEnumerable<B> b, Func<A, B, C> f)
        {
            // zipWith z (a:as) (b:bs) = z a b : zipWith z as bs
            // zipWith _ _ _ = []
            if(IsEmpty(a) || IsEmpty(b)) return Empty<C>();

            var (ax, axs) = (Head(a), Tail(a));
            var (bx, bxs) = (Head(b), Tail(b));

            return AppendFront(f(ax, bx), ZipWith(axs, bxs, f));
        }
        
        /// <summary>
        /// Applied to a binary function and two lists, returns a list containing elements formed be applying the function to corresponding elements in the lists. 
        /// </summary>
        public static IEnumerable<(A, B)> Zip<A, B>(this IEnumerable<A> a, IEnumerable<B> b)
        {
            // zip xs ys
            //   = zipWith pair xs ys
            //   where
            //   pair x y = (x, y)
            return ZipWith(a, b, (x, y) => (x, y));
        }

        /// <summary>
        /// The trigonometric function inverse tan. 
        /// </summary>
        public static double Atan<A>(this double x)
        {
            return System.Math.Atan(x);
        }

        /// <summary>
        /// Returns the smallest integer not less than its argument. 
        /// </summary>
        public static int Ceiling<A>(this double x)
        {
            return (int)System.Math.Ceiling(x);
        }

        /// <summary>
        /// The trigonometric cosine function, arguments are interpreted to be in radians. 
        /// </summary>
        public static int Cos<A>(this double x)
        {
            return (int)System.Math.Cos(x);
        }

        /// <summary>
        /// Applied to to values of the same type which have an ordering defined on them, returns a value of type Ordering which will be: 0 if the two values are equal; 1 if the first value is strictly greater than the second; and -1 if the first value is less than or equal to the second value. 
        /// </summary>
        public static int Compare<A>(this A x, A y) where A : IComparable<A>
        {
            // compare x y
            //    | x == y = EQ
            //    | x >= y = LT
            //    | otherwise = GT
            return x.CompareTo(y);
        }

        /// <summary>
        /// Returns the modulus of its two arguments. 
        /// </summary>
        public static int Mod(this int x, int y)
        {
            if(y < 0) return x < 0 ? -(Abs(x % y) + y) : (Abs(x % y) + y);
            return x % y;
        }

        /// <summary>
        /// Computes the integer division of its integral arguments. 
        /// </summary>
        public static int Div(this int x, int y)
        {
            var ddiv = (double)x / y;
            var idiv = (int)ddiv;

            // `div` is integer division such that the result is truncated towards negative infinity. 
            return ddiv >= 0 ? idiv : idiv - 1;
        }

        /// <summary>
        /// Returns the quotient after dividing the its first integral argument by its second integral argument. 
        /// </summary>
        public static int Quot(this int x, int y)
        {
            return x / y;
        }

        /// <summary>
        /// Returns the remainder after dividing its first integral argument by its second integral argument. 
        /// </summary>
        public static int Rem(this int x, int y)
        {
            // (x `quot` y)*y + (x `rem` y) == x
            return -(Quot(x, y) * y - x);
        }

        /// <summary>
        /// Applied to a string creates an error value with an associated message. 
        /// </summary>
        public static void Error(string message)
        {
            throw new PreludeException(message);
        }

        /// <summary>
        /// Computes the integer division of its integral arguments. 
        /// </summary>
        public static double Exp(this double x)
        {
            return System.Math.Exp(x);
        }

        /// <summary>
        /// Returns the largest integer not greater than its argument.
        /// </summary>
        public static double Floor(this double x)
        {
            return System.Math.Floor(x);
        }

        /// <summary>
        /// Converts from an int to a double type. 
        /// </summary>
        public static double FromIntegral(this int i)
        {
            return (double)i;
        }

        /// <summary>
        /// Applied to a character argument, returns True if the character is a numeral, and False otherwise. [Import from Data.Char] 
        /// </summary>
        public static bool IsDigit(this char c)
        {
            // isDigit c = c >= '0' && c <= '9'
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// Applied to a character argument, returns True if the character is alphabetic, and False otherwise. [Import from Data.Char] 
        /// </summary>
        public static bool IsAlpha(this char c)
        {
            // isAlpha c = isUpper c || isLower c
            return IsUpper(c) || IsLower(c);
        }

        /// <summary>
        /// Returns the natural logarithm of its argument. 
        /// </summary>
        public static double Log(this double x)
        {
            return System.Math.Log(x);
        }

        /// <summary>
        /// Takes a string as an argument and returns an I/O action as a result. A side-effect of applying putStr is that it causes its argument string to be printed to the screen. 
        /// </summary>
        public static Text.StringBuilder PutStr(this string s, Text.StringBuilder sb)
        {
            if(sb == null) sb = new Text.StringBuilder();
            Console.Write(s);
            sb.Append(s);
            return sb;
        }

        /// <summary>
        /// Takes a value of any type in the Show class as an argument and returns an I/O action as a result. A side-effect of applying print is that it causes its argument value to be printed to the screen. 
        /// </summary>
        public static Text.StringBuilder Print<A>(this A s, Text.StringBuilder sb)
        {
            // print x = putStrLn (show x) 
            return PutStr(Show(s), sb);
        }

        private static IEnumerable<A> Skip<A>(IEnumerable<A> xs, int n)
        {
            if(IsEmpty(xs) || n == 0) return xs;
            else if(n > 0) return Skip(Tail(xs), n - 1);
            throw new PreludeException("Skip: negative number");
        }

        private static IEnumerable<A> Empty<A>()
        {
            yield break;
        }

        private static IEnumerable<A> Concat<A>(IEnumerable<A> first, IEnumerable<A> second)
        {
            foreach (var x in first) yield return x;
            foreach (var x in second) yield return x;
        }

        private static IEnumerable<A> AppendFront<A>(A first, IEnumerable<A> xs)
        {
            yield return first;
            foreach (var x in xs) yield return x;
        }

        private static bool IsEmpty<A>(IEnumerable<A> xs)
        {
            foreach (var _ in xs) return false;
            return true;
        }

        private static bool IsLongestThan<A>(IEnumerable<A> xs, uint length, uint minimalLength = 1)
        {
            int counter = 0;
            foreach (var _ in xs)
            {
                if(++counter > length)
                    return true;
            }

            if(counter < minimalLength)
                throw new PreludeException($"Cannot perform this operation on the array with this length (minimalLength: {minimalLength})");
            return false;
        }
    }
}
