using System.Linq;
using System.Collections.Generic;

using static System.Math;

namespace System.Prelude
{
    /// <summary>
    /// The analogy for part of basic function library from my favorite functional language
    /// <see ref="http://www.cse.chalmers.se/edu/course/TDA555/tourofprelude.html"/>
    /// </summary>
    public static class Prelude
    {
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
            if(!IsLongestThan(xs, 1)) return xs.ElementAt(0); else return f(Head(xs), Foldr1(xs.Tail(), f));
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
            return xs.First();
        }

        /// <summary>
        /// Applied to a non--empty list, returns the list without its first element.
        /// </summary>
        public static IEnumerable<A> Tail<A>(this IEnumerable<A> xs)
        {
            // tail (_:xs) = xs
            return xs.Skip(1);
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
                else return (satisfied, xs.Skip(skip));
            }
            return (satisfied, Enumerable.Empty<A>());
        }

        /// <summary>
        ///  Applied to a list of lists, joins them together using the ++ operator. 
        /// </summary>
        public static IEnumerable<A> Concat<A>(this IEnumerable<IEnumerable<A>> xs)
        {
            // concat xs = foldr (++) [] xs
            return Foldr<IEnumerable<A>, IEnumerable<A>>(xs, Enumerable.Concat, Enumerable.Empty<A>());
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
            return char.IsDigit(c) ? c - '0' : 
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
            if(IsEmpty(xs)) return Enumerable.Empty<A>();
            if(n > 0) return xs.Skip(n);
            throw new PreludeException("Drop: negative argument");
        }

        /// <summary>
        /// Applied to an integral argument, returns True if the argument is even, and False otherwise. 
        /// </summary>
        public static bool Even(this int n)
        {
            // even n = n `rem` 2 == 0
            return n % 2 == 0;
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
        public static bool Elem<A>(this IEnumerable<A> xs, A x)
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
            return GCD(Abs(y), Abs(x % y));
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
            if(!IsLongestThan(xxs, 1)) return Enumerable.Empty<A>(); else return AppendFront(Head(xxs), Init(Tail(xxs)));
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
            return !IsLongestThan(xxs, 1) ? xxs.ElementAt(0) : Last(Tail(xxs));
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
            yield return string.Join(string.Empty, l);

            if(IsEmpty(xs)) yield break;
            else 
            {
                foreach (var ll in Lines(string.Join(string.Empty, xs.Skip(1))))
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

        private static IEnumerable<A> AppendFront<A>(A first, IEnumerable<A> xxs)
        {
            yield return first;
            foreach (var x in xxs) yield return x;
        }

        private static bool IsEmpty<A>(IEnumerable<A> xxs)
        {
            foreach (var _ in xxs) return false;
            return true;
        }

        private static bool IsLongestThan<A>(IEnumerable<A> xxs, uint length, uint minimalLength = 1)
        {
            int counter = 0;
            foreach (var _ in xxs)
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
