package jp.co.isid.ham.login.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * xxx
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬 HAM�����o�[<BR>
 * </P>
 *
 * @author
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MprKengenCheckDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�֎~�̂��߁Aprivate�ɂĎ���
     */
    private MprKengenCheckDAOFactory() {

    }

    /**
     * CostManagementDAO���擾���܂�
     *
     * @return
     */
    public static MprKengenCheckDAO createMPRKengenChkDAO() {
        return (MprKengenCheckDAO) DaoFactory.createDao(MprKengenCheckDAO.class);
    }
}
