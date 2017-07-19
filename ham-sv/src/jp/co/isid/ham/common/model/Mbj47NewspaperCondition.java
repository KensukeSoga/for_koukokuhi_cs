package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �V���}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/09/17 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj47NewspaperCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̎�ʃR�[�h */
    private String _npcd = null;

    /** �}�̗����� */
    private String _rname = null;

    /** �G���A */
    private String _area = null;

    /** �˗���R�[�h */
    private String _iraisakicode = null;

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
    public Mbj47NewspaperCondition()
    {
    }

    /**
     * �}�̎�ʃR�[�h���擾����
     *
     * @return �}�̎�ʃR�[�h
     */
    public String getNpcd()
    {
        return _npcd;
    }

    /**
     * �}�̎�ʃR�[�h��ݒ肷��
     *
     * @param npcd �}�̎�ʃR�[�h
     */
    public void setNpcd(String npcd)
    {
        this._npcd = npcd;
    }

    /**
     * �}�̗����̂��擾����
     *
     * @return �}�̗�����
     */
    public String getRname()
    {
        return _rname;
    }

    /**
     * �}�̗����̂�ݒ肷��
     *
     * @param rname �}�̗�����
     */
    public void setRname(String rname)
    {
        this._rname = rname;
    }

    /**
     * �G���A���擾����
     *
     * @return �G���A
     */
    public String getArea()
    {
        return _area;
    }

    /**
     * �G���A��ݒ肷��
     *
     * @param area �G���A
     */
    public void setArea(String area)
    {
        this._area = area;
    }

    /**
     * �˗���R�[�h���擾����
     *
     * @return �˗���R�[�h
     */
    public String getIraisakicode()
    {
        return _iraisakicode;
    }

    /**
     * �˗���R�[�h��ݒ肷��
     *
     * @param iraisakicode �˗���R�[�h
     */
    public void setIraisakicode(String iraisakicode)
    {
        this._iraisakicode = iraisakicode;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate()
    {
        return _upddate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param upddate �f�[�^�X�V����
     */
    public void setUpddate(Date upddate)
    {
        this._upddate = upddate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUpdnm()
    {
        return _updnm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param updnm �f�[�^�X�V��
     */
    public void setUpdnm(String updnm)
    {
        this._updnm = updnm;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl()
    {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl)
    {
        this._updapl = updapl;
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUpdid()
    {
        return _updid;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param updid �X�V�S����ID
     */
    public void setUpdid(String updid)
    {
        this._updid = updid;
    }

}
