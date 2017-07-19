package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR�\�Z��ڃ}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj16CrExpenceCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ��ڃR�[�h */
    private String _expcd = null;

    /** ��ʔ��f�t���O */
    private String _classdiv = null;

    /** �J�n�N���� */
    private Date _datefrom = null;

    /** �I���N���� */
    private Date _dateto = null;

    /** ��ږ� */
    private String _expnm = null;

    /** �\�[�gNo */
    private BigDecimal _sortno = null;

    /** �t���O�P */
    private String _flg1 = null;

    /** �f�[�^�X�V���� */
    private Date _upddate = null;

    /** �f�[�^�X�V�� */
    private String _updnm = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �X�V�S����ID */
    private String _updid = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj16CrExpenceCondition() {
    }

    /**
     * ��ڃR�[�h���擾����
     *
     * @return ��ڃR�[�h
     */
    public String getExpcd() {
        return _expcd;
    }

    /**
     * ��ڃR�[�h��ݒ肷��
     *
     * @param expcd ��ڃR�[�h
     */
    public void setExpcd(String expcd) {
        this._expcd = expcd;
    }

    /**
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getClassdiv() {
        return _classdiv;
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param classdiv ��ʔ��f�t���O
     */
    public void setClassdiv(String classdiv) {
        this._classdiv = classdiv;
    }

    /**
     * �J�n�N�������擾����
     *
     * @return �J�n�N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDatefrom() {
        return _datefrom;
    }

    /**
     * �J�n�N������ݒ肷��
     *
     * @param datefrom �J�n�N����
     */
    public void setDatefrom(Date datefrom) {
        this._datefrom = datefrom;
    }

    /**
     * �I���N�������擾����
     *
     * @return �I���N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateto() {
        return _dateto;
    }

    /**
     * �I���N������ݒ肷��
     *
     * @param dateto �I���N����
     */
    public void setDateto(Date dateto) {
        this._dateto = dateto;
    }

    /**
     * ��ږ����擾����
     *
     * @return ��ږ�
     */
    public String getExpnm() {
        return _expnm;
    }

    /**
     * ��ږ���ݒ肷��
     *
     * @param expnm ��ږ�
     */
    public void setExpnm(String expnm) {
        this._expnm = expnm;
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param sortno �\�[�gNo
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * �t���O�P���擾����
     *
     * @return �t���O�P
     */
    public String getFlg1() {
        return _flg1;
    }

    /**
     * �t���O�P��ݒ肷��
     *
     * @param flg1 �t���O�P
     */
    public void setFlg1(String flg1) {
        this._flg1 = flg1;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param upddate �f�[�^�X�V����
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param updnm �f�[�^�X�V��
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param updid �X�V�S����ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
