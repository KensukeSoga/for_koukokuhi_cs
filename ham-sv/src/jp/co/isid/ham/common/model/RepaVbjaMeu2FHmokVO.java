package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu2FHmok;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ��ڃ}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu2FHmokVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu2FHmokVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu2FHmokVO();
    }

    /**
     * ��ڃR�[�h���擾����
     *
     * @return ��ڃR�[�h
     */
    public String getHMOKCD() {
        return (String) get(RepaVbjaMeu2FHmok.HMOKCD);
    }

    /**
     * ��ڃR�[�h��ݒ肷��
     *
     * @param val ��ڃR�[�h
     */
    public void setHMOKCD(String val) {
        set(RepaVbjaMeu2FHmok.HMOKCD, val);
    }

    /**
     * ���s�N�������擾����
     *
     * @return ���s�N����
     */
    public String getHKYMD() {
        return (String) get(RepaVbjaMeu2FHmok.HKYMD);
    }

    /**
     * ���s�N������ݒ肷��
     *
     * @param val ���s�N����
     */
    public void setHKYMD(String val) {
        set(RepaVbjaMeu2FHmok.HKYMD, val);
    }

    /**
     * �p�~�N�������擾����
     *
     * @return �p�~�N����
     */
    public String getHAISYMD() {
        return (String) get(RepaVbjaMeu2FHmok.HAISYMD);
    }

    /**
     * �p�~�N������ݒ肷��
     *
     * @param val �p�~�N����
     */
    public void setHAISYMD(String val) {
        set(RepaVbjaMeu2FHmok.HAISYMD, val);
    }

    /**
     * ���e�i�J�i�j���擾����
     *
     * @return ���e�i�J�i�j
     */
    public String getNAIYKN() {
        return (String) get(RepaVbjaMeu2FHmok.NAIYKN);
    }

    /**
     * ���e�i�J�i�j��ݒ肷��
     *
     * @param val ���e�i�J�i�j
     */
    public void setNAIYKN(String val) {
        set(RepaVbjaMeu2FHmok.NAIYKN, val);
    }

    /**
     * ���e�i�����j���擾����
     *
     * @return ���e�i�����j
     */
    public String getNAIYJ() {
        return (String) get(RepaVbjaMeu2FHmok.NAIYJ);
    }

    /**
     * ���e�i�����j��ݒ肷��
     *
     * @param val ���e�i�����j
     */
    public void setNAIYJ(String val) {
        set(RepaVbjaMeu2FHmok.NAIYJ, val);
    }

    /**
     * �o����ڕ\���敪���擾����
     *
     * @return �o����ڕ\���敪
     */
    public String getKRIHMOKSHOWKBN() {
        return (String) get(RepaVbjaMeu2FHmok.KRIHMOKSHOWKBN);
    }

    /**
     * �o����ڕ\���敪��ݒ肷��
     *
     * @param val �o����ڕ\���敪
     */
    public void setKRIHMOKSHOWKBN(String val) {
        set(RepaVbjaMeu2FHmok.KRIHMOKSHOWKBN, val);
    }

}
