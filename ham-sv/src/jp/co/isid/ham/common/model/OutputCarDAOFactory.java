package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���[�o�͎Ԏ�DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputCarDAOFactory extends DaoFactory{
    /**
     * �C���X�^���X�̐����֎~
     */
    private OutputCarDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static OutputCarDAO createOutputCarDAO() {
        return (OutputCarDAO) DaoFactory.createDao(OutputCarDAO.class);
    }
}
