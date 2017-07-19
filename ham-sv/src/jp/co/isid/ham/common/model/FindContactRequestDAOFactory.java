package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �˗���DAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/08/02 T.Fujiyoshi)<BR>
 * </P>
 *
 * @author T.Fujiyoshi
 */
public class FindContactRequestDAOFactory extends DaoFactory {

    private FindContactRequestDAOFactory() {
    }

    /**
     * �˗���DAO�C���X�^���X�𐶐����܂�
     *
     * @return �˗���DAO
     */
    public static FindContactRequestDAO createFindContactRequestDAO() {
        return (FindContactRequestDAO) DaoFactory.createDao(FindContactRequestDAO.class);
    }

}
