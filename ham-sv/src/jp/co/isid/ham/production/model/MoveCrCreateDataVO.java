package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;

/**
 * <P>
 * CR�����\�f�[�^�ړ��^�R�s�[�@�o�^���s���̓o�^�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MoveCrCreateDataVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _userid = null;

    /** �S���Җ� */
    private String _usernm = null;

    /** ���ID */
    private String _formid = null;

    /** CR�����Ǘ��̍ő�^�C���X�^���v */
    private Date _maxDateTimeForCrCreateData = null;

    /** CR�����Ǘ�VO���X�g */
    private List<Tbj11CrCreateDataVO> _tbj11CrCreateDataVoList = null;

    /** �d�ʎԎ�R�[�h */
    private String _dCarCd = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �N�� */
    private Date _crDate = null;

    /** ��ʔ��f�t���O */
    private String _classDiv = null;

    /** �������(0:�ړ��A1:�R�s�[) */
    private int _execKind = 0;

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getUserid() {
        return _userid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param userid �S����ID
     */
    public void setUserid(String userid) {
        this._userid = userid;
    }

    /**
     * �S���Җ����擾����
     *
     * @return �S���Җ�
     */
    public String getUsernm() {
        return _usernm;
    }

    /**
     * �S���Җ���ݒ肷��
     *
     * @param userid �S���Җ�
     */
    public void setUsernm(String usernm) {
        this._usernm = usernm;
    }

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formid ���ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

    /**
     * CR�����Ǘ��̃^�C���X�^���v�ő�l���擾����
     *
     * @return CR�����Ǘ��̃^�C���X�^���v�ő�l
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTimeForCrCreateData() {
        return _maxDateTimeForCrCreateData;
    }

    /**
     * CR�����Ǘ��̃^�C���X�^���v�ő�l��ݒ肷��
     *
     * @param maxDateTimeForCrCarInfo CR�����Ǘ��̃^�C���X�^���v�ő�l
     */
    public void setMaxDateTimeForCrCreateData(Date maxDateTimeForCrCreateData) {
        this._maxDateTimeForCrCreateData = maxDateTimeForCrCreateData;
    }

    /**
     * CR�����Ǘ�VO�i�o�^�j���X�g���擾����
     *
     * @return CR�����Ǘ�VO�i�o�^�j���X�g
     */
    @XmlElement(required = true, nillable=true)
    public List<Tbj11CrCreateDataVO> getTbj11CrCreateDataVoList() {
        return _tbj11CrCreateDataVoList;
    }

    /**
     * CR�����Ǘ�VO�i�o�^�j���X�g��ݒ肷��
     *
     * @param tbj11CrCreateDataVoListReg CR�����Ǘ�VO�i�o�^�j���X�g
     */
    public void setTbj11CrCreateDataVoList(List<Tbj11CrCreateDataVO> tbj11CrCreateDataVoList) {
        this._tbj11CrCreateDataVoList = tbj11CrCreateDataVoList;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param dcarcd �d�ʎԎ�R�[�h
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable=true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable=true)
    public Date getCrDate() {
        return _crDate;
    }

    /**
     * �N����ݒ肷��
     *
     * @param crdate �N��
     */
    public void setCrDate(Date crDate) {
        this._crDate = crDate;
    }

    /**
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getClassDiv() {
        return _classDiv;
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param dcarcd �d�ʎԎ�R�[�h
     */
    public void setClassDiv(String classDiv) {
        this._classDiv = classDiv;
    }

    /**
     * ������ʂ��擾����
     *
     * @return �������
     */
    public int getExecKind() {
        return _execKind;
    }

    /**
     * ������ʂ�ݒ肷��
     *
     * @param dcarcd �������
     */
    public void setExecKind(int execKind) {
        this._execKind = execKind;
    }


}
