"""empty message

Revision ID: 2dedd4b8fe4c
Revises: 3a308c077178
Create Date: 2019-04-07 17:11:57.638592

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '2dedd4b8fe4c'
down_revision = '3a308c077178'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.add_column('user', sa.Column('address_city', sa.String(length=50), nullable=False))
    op.add_column('user', sa.Column('address_country', sa.String(length=50), nullable=False))
    op.add_column('user', sa.Column('address_line1', sa.String(length=100), nullable=False))
    op.add_column('user', sa.Column('address_line2', sa.String(length=50), nullable=False))
    op.add_column('user', sa.Column('address_postal_code', sa.String(length=10), nullable=False))
    op.add_column('user', sa.Column('first_name', sa.String(length=50), nullable=False))
    op.add_column('user', sa.Column('last_name', sa.String(length=50), nullable=False))
    op.add_column('user', sa.Column('permission_level', sa.Integer(), nullable=False))
    op.add_column('user', sa.Column('user_config', sa.Text(), nullable=False))
    op.drop_constraint('user_username_key', 'user', type_='unique')
    op.drop_column('user', 'username')
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.add_column('user', sa.Column('username', sa.VARCHAR(length=50), autoincrement=False, nullable=True))
    op.create_unique_constraint('user_username_key', 'user', ['username'])
    op.drop_column('user', 'user_config')
    op.drop_column('user', 'permission_level')
    op.drop_column('user', 'last_name')
    op.drop_column('user', 'first_name')
    op.drop_column('user', 'address_postal_code')
    op.drop_column('user', 'address_line2')
    op.drop_column('user', 'address_line1')
    op.drop_column('user', 'address_country')
    op.drop_column('user', 'address_city')
    # ### end Alembic commands ###
