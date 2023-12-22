from io import StringIO
import unittest
from unittest.mock import patch, mock_open
import main

class TestProgram(unittest.TestCase):

    @patch("builtins.open", mock_open(read_data="test data"))
    def test_filter_operators_ending_with_nt(self):
        expected_result = [('Increment', '++', 1, 'C++'), ('Assignment', ':=', 2, 'Pascal')]
        with patch("sys.stdout", new_callable=StringIO) as mock_stdout:
            main.main()
            actual_output = mock_stdout.getvalue()
            self.assertTrue(all(str(operator) in actual_output for operator in expected_result))

    @patch("builtins.open", mock_open(read_data="test data"))
    def test_average_arity_of_language(self):
        expected_result = [('Java', 3.0), ('C#', 2.0), ('Pascal', 2.0), ('Python', 2.0), ('C++', 1.5)]
        with patch("sys.stdout", new_callable=StringIO) as mock_stdout:
            main.main()
            actual_output = mock_stdout.getvalue()
            self.assertTrue(all(str(language) in actual_output for language in expected_result))

    @patch("builtins.open", mock_open(read_data="test data"))
    def test_filter_languages_starting_with_c(self):
        expected_result = {'C++': ['Array index', 'Increment', 'Equality', 'Ternary operator'],
                           'C#': ['Array index', 'Increment', 'Equality', 'Null coalescing', 'Ternary operator']}
        with patch("sys.stdout", new_callable=StringIO) as mock_stdout:
            main.main()
            actual_output = mock_stdout.getvalue()
            self.assertTrue(all(language in actual_output for language in expected_result.keys()))
            self.assertTrue(all(all(operator in actual_output for operator in operators) for language, operators in expected_result.items()))

if __name__ == '__main__':
    unittest.main()
