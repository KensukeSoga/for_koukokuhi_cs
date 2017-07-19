package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���[�o�͐ݒ�X�VDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/10 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class ExcelOutSettingRegisterDAOFactory extends DaoFactory{

    private ExcelOutSettingRegisterDAOFactory() {
    }

    /**
     * ���[�o�͔}�̓o�^DAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static ExcelOutMediaRegisterDAO createExcelOutMediaRegisterDAO() {
        return (ExcelOutMediaRegisterDAO) DaoFactory.createDao(ExcelOutMediaRegisterDAO.class);
    }

    /**
     * ���[�o�͎Ԏ�o�^DAO�C���X�^���X�𐶐����܂�
     * @return DAO�C���X�^���X
     */
    public static ExcelOutCarRegisterDAO createExcelOutCarRegisterDAO() {
        return (ExcelOutCarRegisterDAO) DaoFactory.createDao(ExcelOutCarRegisterDAO.class);
    }
}
