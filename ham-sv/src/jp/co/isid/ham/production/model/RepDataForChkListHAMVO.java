package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * BudgetDAO.findBudget�Ŏ擾�����f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/07 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RepDataForChkListHAMVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepDataForChkListHAMVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepDataForChkListHAMVO();
    }
    /**
     * ��No.���擾����
     *
     * @return ��No.
     */
    public String getORDERNO() {
        return (String) get(Tbj11CrCreateData.ORDERNO);
    }

    /**
     * ��No.��ݒ肷��
     *
     * @param val ��No.
     */
    public void setORDERNO(String val) {
        set(Tbj11CrCreateData.ORDERNO, val);
    }
    /**
     * �Ԏ햼���擾����
     *
     * @return �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     *
     * @param val �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }
    /**
     * �\�Z�\��ڂ��擾����
     *
     * @return �\�Z�\���
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * �\�Z�\��ڂ�ݒ肷��
     *
     * @param val �\�Z�\���
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }
    /**
     * ��ڂ��擾����
     *
     * @return ���
     */
    public String getEXPENSE() {
        return (String) get(Tbj11CrCreateData.EXPENSE);
    }

    /**
     * ��ڂ�ݒ肷��
     *
     * @param val ���
     */
    public void setEXPENSE(String val) {
        set(Tbj11CrCreateData.EXPENSE, val);
    }
    /**
     * �ڍׂ��擾����
     *
     * @return �ڍ�
     */
    public String getDETAIL() {
        return (String) get(Tbj11CrCreateData.DETAIL);
    }

    /**
     * �ڍׂ�ݒ肷��
     *
     * @param val �ڍ�
     */
    public void setDETAIL(String val) {
        set(Tbj11CrCreateData.DETAIL, val);
    }
    /**
     * ������f���D���擾����
     *
     * @return ������f���D
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * ������f���D��ݒ肷��
     *
     * @param val ������f���D
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }
    /**
     * �[�i�����擾����
     *
     * @return �[�i��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj11CrCreateData.DELIVERDAY);
    }

    /**
     * �[�i����ݒ肷��
     *
     * @param val �[�i��
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj11CrCreateData.DELIVERDAY, val);
    }
    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.CLMMONEY);
    }

    /**
     * �������z��ݒ肷��
     *
     * @param val �������z
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.CLMMONEY, val);
    }

    /**
     * �敪���擾����
     *
     * @return �敪
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * �敪��ݒ肷��
     *
     * @param val �敪
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * ���͒S���҂��擾����
     *
     * @return ���͒S����
     */
    public String getINPUTTNTNM() {
        return (String) get(Mbj30InputTnt.INPUTTNT);
    }

    /**
     * ���͒S���҂�ݒ肷��
     *
     * @param val ���͒S����
     */
    public void setINPUTTNTNM(String val) {
        set(Mbj30InputTnt.INPUTTNT, val);
    }


}
