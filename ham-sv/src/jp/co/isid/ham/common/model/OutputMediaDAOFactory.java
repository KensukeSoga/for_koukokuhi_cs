package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���[�o�͔}��DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputMediaDAOFactory extends DaoFactory{

    /**
     * �C���X�^���X�̐����֎~
     */
    private OutputMediaDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static OutputMediaDAO createOutputMediaDAO() {
        return (OutputMediaDAO) DaoFactory.createDao(OutputMediaDAO.class);
    }
}