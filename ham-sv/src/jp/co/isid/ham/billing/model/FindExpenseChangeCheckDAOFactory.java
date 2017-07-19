package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �����ύX�_�m�FDAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/12 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExpenseChangeCheckDAOFactory extends DaoFactory {


    /**
     * �C���X�^���X�����֎~
     */
    private FindExpenseChangeCheckDAOFactory() {
    }

    /**
     * ���݂̐��쌴���擾DAO�C���X�^���X�𐶐����܂�
     *
     * @return ���݂̐��쌴���擾DAO�C���X�^���X
     */
    public static FindNowExpenseDAO createFindNowExpenseDao() {
        return new FindNowExpenseDAO();
    }

    /**
     *  ���쎞�̐��쌴���擾DAO�C���X�^���X�𐶐����܂�
     *
     *  @return ���쎞�̐��쌴���擾DAO�C���X�^���X
     */
    public static FindBeforeExpenseDAO createFindBeforeExpenseDao() {
        return new FindBeforeExpenseDAO();
    }
}
