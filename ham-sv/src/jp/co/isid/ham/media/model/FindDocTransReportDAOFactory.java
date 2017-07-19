package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

public class FindDocTransReportDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindDocTransReportDAOFactory() {
    }

    /**
     * ���e�\�̒��[���擾�̃C���X�^���X��Ԃ�
     *
     * @return ���e�\�̒��[���擾�̃C���X�^���X
     */
    public static FindDocTransReportDAO createFindDocTransReportDAO() {
        return (FindDocTransReportDAO) DaoFactory.createDao(FindDocTransReportDAO.class);
    }
}
