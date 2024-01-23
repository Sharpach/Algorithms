import unittest

from Algorithms.AlgorithmsPython import binary_search


class TestBinarySearch(unittest.TestCase):

    def test_binary_search(self):
        self.assertEqual(binary_search([], 1), None)
        self.assertEqual(binary_search([0], 0), 0)
        self.assertEqual(binary_search([0, 0], 1), None)
        self.assertEqual(binary_search([0, 0, 0], 0), 1)
        self.assertEqual(binary_search([1, 2], 1), 0)
        self.assertEqual(binary_search([1, 2], 2), 1)
        self.assertEqual(binary_search([1, 2, 3, 4], 1), 0)
        self.assertEqual(binary_search([1, 2, 3, 4], 2), 1)
        self.assertEqual(binary_search([1, 2, 3, 4], 3), 2)
        self.assertEqual(binary_search([1, 2, 3, 4], 4), 3)


if __name__ == '__main__':
    unittest.main()
