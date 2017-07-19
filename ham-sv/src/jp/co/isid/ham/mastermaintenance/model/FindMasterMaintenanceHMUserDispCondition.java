package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj48HmUserCondition;

/**
 * <P>
 * HM�S���ҕ\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHMUserDispCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HM�S���҃}�X�^�������� */
    private Mbj48HmUserCondition _conditionHMUser;
    /** �R�[�h�}�X�^�������� */
    private Mbj12CodeCondition _conditionCode;

    /**
     * HM�S���҃}�X�^����������ݒ肷��
     * @param cond Mbj48HmUserCondition HM�S���҃}�X�^��������
     */
    public void setConditionHMUser(Mbj48HmUserCondition cond) {
        _conditionHMUser = cond;
    }

    /**
     * HM�S���҃}�X�^�����������擾����
     * @return Mbj48HmUserCondition HM�S���҃}�X�^��������
     */
    public Mbj48HmUserCondition getConditionHMUser() {
        return _conditionHMUser;
    }

    /**
     * �R�[�h�}�X�^�����������擾����
     * @param cond Mbj12CodeCondition �R�[�h�}�X�^��������
     */
    public void setConditionCode(Mbj12CodeCondition cond) {
        _conditionCode = cond;
    }

    /**
     * �R�[�h�}�X�^����������ݒ肷��
     * @return Mbj12CodeCondition �R�[�h�}�X�^��������
     */
    public Mbj12CodeCondition getConditionCode() {
        return _conditionCode;
    }

}
