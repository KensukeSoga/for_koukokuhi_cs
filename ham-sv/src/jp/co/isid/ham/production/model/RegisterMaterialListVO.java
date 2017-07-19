package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnVO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;

/**
 * <P>
 * �f�ވꗗ�@�o�^���s���̓o�^�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * �EHDX�Ή�(2016/02/23 HLC K.Soga)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterMaterialListVO implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * ��������
     */
    private MaterialListCondition _materialListCondition = null;

    /**
     * �f�ޓo�^�p�o�^��
     */
    private Date _materialDate = null;

    /**
     * �f�ވꗗ�o�^�pVO���X�g
     */
    private List<RegisterMaterialListUpdateVO> _regList = null;

    /**
     * �f�ވꗗ�X�V�pVO���X�g
     */
    private List<RegisterMaterialListUpdateVO> _updList = null;

    /**
     * �f�ވꗗ�폜�pVO���X�g
     */
    private List<RegisterMaterialListUpdateVO> _delList = null;

    /**
     * �Ԏ�ϊ��}�X�^VO
     */
    private Mbj38CarConvertVO _carConvert = null;

    /** 2016/02/23 HDX�Ή� HLC K.Soga ADD Start */
    /**
     * �f�ވꗗ(����)�o�^�pVO
     */
    private List<Tbj42SozaiKanriListCmnVO> _tbj42RegList = null;

    /**
     * �f�ވꗗ(����)�X�V�pVO
     */
    private List<Tbj42SozaiKanriListCmnVO> _tbj42UpdList = null;

    /**
     * �f�ވꗗ(����)�폜�pVO
     */
    private List<Tbj42SozaiKanriListCmnVO> _tbj42DelList = null;

    /**
     * �f�ވꗗ(����OA����)�o�^�pVO
     */
    private List<Tbj43SozaiKanriListCmnOAVO> _tbj43RegList = null;

    /**
     * �f�ވꗗ(����OA����)�X�V�pVO
     */
    private List<Tbj43SozaiKanriListCmnOAVO> _tbj43UpdList = null;

    /**
     * �f�ވꗗ(����OA����)�폜�pVO
     */
    private List<Tbj43SozaiKanriListCmnOAVO> _tbj43DelList = null;
    /** 2016/02/23 HDX�Ή� HLC K.Soga ADD End */

    /**
     * �f�ޓo�^�p�o�^����ݒ肵�܂�
     * @param dt
     */
    public void setMaterialDate(Date dt) {
        _materialDate = dt;
    }

    /**
     * �f�ޓo�^�p�o�^�����擾���܂�
     * @param dt
     */
    public Date getMaterialDate() {
        return _materialDate;
    }

    /**
     * ����������ݒ肵�܂�
     * @param cond
     */
    public void setMaterialListCondition(MaterialListCondition cond) {
        _materialListCondition = cond;
    }

    /**
     * �����������擾���܂�
     * @return
     */
    public MaterialListCondition getMaterialListCondition() {
        return _materialListCondition;
    }

    /**
     * �f�ވꗗ�o�^�pVO���X�g��ݒ肵�܂�
     * @param vo
     */
    public void setRegVOList(List<RegisterMaterialListUpdateVO> vo) {
        _regList = vo;
    }

    /**
     * �f�ވꗗ�o�^�pVO���X�g���擾���܂�
     * @return
     */
    public List<RegisterMaterialListUpdateVO> getRegVOList() {
        return _regList;
    }

    /**
     * �f�ވꗗ�X�V�pVO���X�g��ݒ肵�܂�
     * @param vo
     */
    public void setUpdVOList(List<RegisterMaterialListUpdateVO> vo) {
        _updList = vo;
    }

    /**
     * �f�ވꗗ�X�V�pVO���X�g���擾���܂�
     * @return
     */
    public List<RegisterMaterialListUpdateVO> getUpdVOList() {
        return _updList;
    }

    /**
     * �f�ވꗗ�폜�pVO���X�g��ݒ肵�܂�
     * @param vo
     */
    public void setDelVOList(List<RegisterMaterialListUpdateVO> vo) {
        _delList = vo;
    }

    /**
     * �f�ވꗗ�폜�pVO���X�g���擾���܂�
     * @return
     */
    public List<RegisterMaterialListUpdateVO> getDelVOList() {
        return _delList;
    }

    /**
     * �Ԏ�ϊ��}�X�^VO��ݒ肵�܂�
     * @param vo
     */
    public void setCarConvert(Mbj38CarConvertVO vo) {
        _carConvert = vo;
    }

    /**
     * �Ԏ�ϊ��}�X�^VO���擾���܂�
     * @return
     */
    public Mbj38CarConvertVO getCarConvert() {
        return _carConvert;
    }

    /** 2016/02/23 HDX�Ή� HLC K.Soga ADD Start */
    /**
     * �f�ވꗗ(����)�o�^�pVO���擾����
     * @return List<Tbj42SozaiKanriListCmnVO> �f�ވꗗ(����)�o�^�pVO
     */
    public List<Tbj42SozaiKanriListCmnVO> getTbj42RegVOList() {
        return _tbj42RegList;
    }

    /**
     * �f�ވꗗ(����)�o�^�pVO��ݒ肷��
     * @param vo List<Tbj42SozaiKanriListCmnVO> �f�ވꗗ(����)�o�^�pVO
     */
    public void setTbj42RegVOList(List<Tbj42SozaiKanriListCmnVO> vo) {
        _tbj42RegList = vo;
    }

    /**
     * �f�ވꗗ(����)�X�V�pVO���擾����
     * @return List<Tbj42SozaiKanriListCmnVO> �f�ވꗗ(����)�X�V�pVO
     */
    public List<Tbj42SozaiKanriListCmnVO> getTbj42UpdVOList() {
        return _tbj42UpdList;
    }

    /**
     * �f�ވꗗ(����)�X�V�pVO��ݒ肷��
     * @param vo List<Tbj42SozaiKanriListCmnVO> �f�ވꗗ(����)�X�V�pVO
     */
    public void setTbj42UpdVOList(List<Tbj42SozaiKanriListCmnVO> vo) {
        _tbj42UpdList = vo;
    }

    /**
     * �f�ވꗗ(����)�폜�pVO���擾����
     * @return List<Tbj42SozaiKanriListCmnVO> �f�ވꗗ(����)�폜�pVO
     */
    public List<Tbj42SozaiKanriListCmnVO> getTbj42DelVOList() {
        return _tbj42DelList;
    }

    /**
     * �f�ވꗗ(����)�폜�pVO��ݒ肷��
     * @param vo List<Tbj42SozaiKanriListCmnVO> �f�ވꗗ(����)�폜�pVO
     */
    public void setTbj42DelVOList(List<Tbj42SozaiKanriListCmnVO> vo) {
        _tbj42DelList = vo;
    }

    /**
     * �f�ވꗗ(����OA����)�o�^�pVO���擾����
     * @return List<Tbj43SozaiKanriListCmnOAVO> �f�ވꗗ(����OA����)�o�^�pVO
     */
    public List<Tbj43SozaiKanriListCmnOAVO> getTbj43RegVOList() {
        return _tbj43RegList;
    }

    /**
     * �f�ވꗗ(����OA����)�o�^�pVO��ݒ肷��
     * @param vo List<Tbj43SozaiKanriListCmnOAVO> �f�ވꗗ(����OA����)�o�^�pVO
     */
    public void setTbj43RegVOList(List<Tbj43SozaiKanriListCmnOAVO> vo) {
        _tbj43RegList = vo;
    }

    /**
     * �f�ވꗗ(����OA����)�X�V�pVO���擾����
     * @return List<Tbj43SozaiKanriListCmnOAVO> �f�ވꗗ(����OA����)�X�V�pVO
     */
    public List<Tbj43SozaiKanriListCmnOAVO> getTbj43UpdVOList() {
        return _tbj43UpdList;
    }

    /**
     * �f�ވꗗ(����OA����)�X�V�pVO��ݒ肷��
     * @param vo List<Tbj43SozaiKanriListCmnOAVO> �f�ވꗗ(����OA����)�X�V�pVO
     */
    public void setTbj43UpdVOList(List<Tbj43SozaiKanriListCmnOAVO> vo) {
        _tbj43UpdList = vo;
    }

    /**
 * �f�ވꗗ(����OA����)�폜�pVO���擾����
     * @return List<Tbj43SozaiKanriListCmnOAVO> �f�ވꗗ(����OA����)�폜�pVO
     */
    public List<Tbj43SozaiKanriListCmnOAVO> getTbj43DelVOList() {
        return _tbj43DelList;
    }

    /**
     * �f�ވꗗ(����OA����)�폜�pVO��ݒ肷��
     * @param vo List<Tbj43SozaiKanriListCmnOAVO> �f�ވꗗ(����OA����)�폜�pVO
     */
    public void setTbj43DelVOList(List<Tbj43SozaiKanriListCmnOAVO> vo) {
        _tbj43DelList = vo;
    }
    /** 2016/02/23 HDX�Ή� HLC K.Soga ADD End */
}
