from flask_restplus import Namespace, fields


class UserDto:
    api = Namespace('user', description='user related operations')
    user = api.model('user', {
        'email': fields.String(required=True, description='user email address'),
        'username': fields.String(required=True, description='user username'),
        'password': fields.String(required=True, description='user password'),
        'public_id': fields.String(description='user Identifier'),
        'first_name': fields.String(description='user first name'),
        'last_name': fields.String(description='user user last name'),
        'user_config': fields.String(description='user config data'),
        'address_line1': fields.String(description='user address line 1'),
        'address_line2': fields.String(description='user address line 2'),
        'address_city': fields.String(description='user address city'),
        'address_postal_code': fields.String(description='user address postal code'),
        'address_country': fields.String(description='user address country'),
    })


class AuthDto:
    api = Namespace('auth', description='authentication related operations')
    user_auth = api.model('auth_details', {
        'email': fields.String(required=True, description='The email address'),
        'password': fields.String(required=True, description='The user password '),
    })
