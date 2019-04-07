import unittest

import datetime

from app.main import db
from app.main.model.user import User
from app.test.base import BaseTestCase


class TestUserModel(BaseTestCase):

    def test_encode_auth_token(self):
        user = User(
            email='test@test.com',
            password='test',
            registered_on=datetime.datetime.utcnow(),
            first_name='Joe',
            last_name='Anderson',
            address_line1='12 Peanut Lane',
            address_line2='',
            address_city='Breakfast City',
            address_postal_code='1234',
            address_country='South Africa',
            permission_level=1,
            user_config='{}'
        )
        db.session.add(user)
        db.session.commit()
        auth_token = User.encode_auth_token(user.id)
        self.assertTrue(isinstance(auth_token, bytes))

    def test_decode_auth_token(self):
        user = User(
            email='test@test.com',
            password='test',
            registered_on=datetime.datetime.utcnow(),
            first_name='Joe',
            last_name='Anderson',
            address_line1='12 Peanut Lane',
            address_line2='',
            address_city='Breakfast City',
            address_postal_code='1234',
            address_country='South Africa',
            permission_level=1,
            user_config='{}'
        )
        db.session.add(user)
        db.session.commit()
        auth_token = User.encode_auth_token(user.id)
        self.assertTrue(isinstance(auth_token, bytes))
        self.assertTrue(User.decode_auth_token(auth_token.decode("utf-8") ) == 1)


if __name__ == '__main__':
    unittest.main()

