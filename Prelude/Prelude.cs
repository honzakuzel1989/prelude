using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Prelude
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
                throw new ArgumentException("DigitToInt: not a digit")));
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
            throw new ArgumentException("Drop: negative argument");
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

        private static bool IsEmpty<A>(IEnumerable<A> xs)
        {
            return !xs.Any();
        }
    }
}
