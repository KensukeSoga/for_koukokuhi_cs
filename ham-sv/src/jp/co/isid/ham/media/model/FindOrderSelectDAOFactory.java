package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

public class FindOrderSelectDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindOrderSelectDAOFactory() {
    }

    /**
     * �c�ƍ�Ƒ䒠�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static FindOrderSelectDAO createOrderSelectDAOFactory() {
        return (FindOrderSelectDAO) DaoFactory.createDao(FindOrderSelectDAO.class);
    }

}
