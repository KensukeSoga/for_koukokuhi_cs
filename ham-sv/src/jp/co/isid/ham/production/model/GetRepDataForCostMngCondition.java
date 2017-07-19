package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR�����@�N�����f�[�^�擾�̏����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetRepDataForCostMngCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid = null;

    /** ���쌴���\(������)�̏o�͗L��(true:�o�͂���Afalse:�o�͂��Ȃ�) */
    private boolean _outFlgGenkaMeisai = false;

    /** ���쌴���\(���v���)�̏o�͗L��(true:�o�͂���Afalse:�o�͂��Ȃ�) */
    private boolean _outFlgGenkaToukei = false;

    /** �����\(������)�̏o�͗L��(true:�o�͂���Afalse:�o�͂��Ȃ�) */
    private boolean _outFlgSeisakuMeisai = false;

    /** �����\(���v���)�̏o�͗L��(true:�o�͂���Afalse:�o�͂��Ȃ�) */
    private boolean _outFlgSeisakuToukei = false;

    /** �t�F�C�Y */
    private int _phase = 0;

    /** �N��(From) */
    private Date _fromDate = null;

    /** �N��(To) */
    private Date _toDate = null;

    /** ����  */
    private String _classCd = null;

    /** ���  */
    private String _exp = null;

    /** �Ԏ탊�X�g */
    private List<String> _carList = null;

    /** ���͒S���҃��X�g */
    private List<String> _inputTntList = null;

    /** ���͒S���Җ����͑Ώۃt���O */
    private boolean _inputTntNullFlg = false;

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * ���쌴���\(������)�̏o�͗L���t���O���擾����
     *
     * @return outFlgGenkaMeisai
     */
    public boolean getOutFlgGenkaMeisai() {
        return _outFlgGenkaMeisai;
    }

    /**
     * ���쌴���\(������)�̏o�͗L���t���O��ݒ肷��
     * @param outFlgGenkaMeisai ���쌴���\(������)�̏o�͗L���t���O
     */
    public void setOutFlgGenkaMeisai(boolean outFlgGenkaMeisai) {
        this._outFlgGenkaMeisai = outFlgGenkaMeisai;
    }

    /**
     * ���쌴���\(���v���)�̏o�͗L���t���O���擾����
     *
     * @return outFlgGenkaToukei
     */
    public boolean getOutFlgGenkaToukei() {
        return _outFlgGenkaToukei;
    }

    /**
     * ���쌴���\(���v���)�̏o�͗L���t���O��ݒ肷��
     * @param outFlgGenkaToukei ���쌴���\(���v���)�̏o�͗L���t���O
     */
    public void setOutFlgGenkaToukei(boolean outFlgGenkaToukei) {
        this._outFlgGenkaToukei = outFlgGenkaToukei;
    }

    /**
     * �����\(������)�̏o�͗L���t���O���擾����
     *
     * @return outFlgSeisakuMeisai
     */
    public boolean getOutFlgSeisakuMeisai() {
        return _outFlgSeisakuMeisai;
    }

    /**
     * �����\(������)�̏o�͗L���t���O��ݒ肷��
     * @param outFlgSeisakuMeisai �����\(������)�̏o�͗L���t���O
     */
    public void setOutFlgSeisakuMeisai(boolean outFlgSeisakuMeisai) {
        this._outFlgSeisakuMeisai = outFlgSeisakuMeisai;
    }

    /**
     * �����\(���v���)�̏o�͗L���t���O���擾����
     *
     * @return outFlgSeisakuToukei
     */
    public boolean getOutFlgSeisakuToukei() {
        return _outFlgSeisakuToukei;
    }

    /**
     * �����\(���v���)�̏o�͗L���t���O��ݒ肷��
     * @param outFlgSeisakuToukei �����\(���v���)�̏o�͗L���t���O
     */
    public void setOutFlgSeisakuToukei(boolean outFlgSeisakuToukei) {
        this._outFlgSeisakuToukei = outFlgSeisakuToukei;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return phase
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param phase phase
     */
    public void setPhase(int phase) {
        this._phase = phase;
    }

    /**
     * �N��(From)���擾����
     *
     * @return fromDate
     */
    @XmlElement(required = true, nillable = true)
    public Date getFromDate() {
        return _fromDate;
    }

    /**
     * �N��(From)��ݒ肷��
     * @param fromDate �N��(From)
     */
    public void setFromDate(Date fromDate) {
        this._fromDate = fromDate;
    }

    /**
     * �N��(To)���擾����
     *
     * @return �N��(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getToDate() {
        return _toDate;
    }

    /**
     * �N��(To)��ݒ肷��
     * @param toDate �N��(To)
     */
    public void setToDate(Date toDate) {
        this._toDate = toDate;
    }

    /**
     * ���ނ��擾����
     *
     * @return classCd
     */
    public String getClassCd() {
        return _classCd;
    }

    /**
     * ���ނ�ݒ肷��
     * @param classCd ����
     */
    public void setClassCd(String classCd) {
        this._classCd = classCd;
    }

    /**
     * ��ڂ��擾����
     *
     * @return exp
     */
    public String getExp() {
        return _exp;
    }

    /**
     * ��ڂ�ݒ肷��
     * @param exp ���
     */
    public void setExp(String exp) {
        this._exp = exp;
    }

    /**
     * �Ԏ탊�X�g���擾����
     *
     * @return carList
     */
    public List<String> getCarList() {
        return _carList;
    }

    /**
     * �Ԏ탊�X�g��ݒ肷��
     * @param carList �Ԏ탊�X�g
     */
    public void setCarList(List<String> carList) {
        this._carList = carList;
    }

    /**
     * ���͒S���҃��X�g���擾����
     *
     * @return inputTntList
     */
    public List<String> getInputTntList() {
        return _inputTntList;
    }

    /**
     * ���͒S���҃��X�g��ݒ肷��
     * @param inputTntList ���͒S���҃��X�g
     */
    public void setInputTntList(List<String> inputTntList) {
        this._inputTntList = inputTntList;
    }

    /**
     * ���͒S���Җ����͑Ώۃt���O���擾����
     *
     * @return inputTntList
     */
    public boolean getInputTntNullFlg() {
        return _inputTntNullFlg;
    }

    /**
     * ���͒S���Җ����͑Ώۃt���O��ݒ肷��
     * @param inputTntList ���͒S���Җ����͑Ώۃt���O
     */
    public void setInputTntNullFlg(boolean inputTntNullFlg) {
        this._inputTntNullFlg =  inputTntNullFlg;
    }

}
